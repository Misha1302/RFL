namespace RFL.Scripts.GameLogic.Player
{
    using System;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class PlayerDownStepper : MonoBeh
    {
        private readonly RaycastHit2D[] _result = new RaycastHit2D[CollectionsLength.MaxHitsCount];
        private PlayerStepper _playerStepper;

        private static Vector2 Input => Services.InputService.Input;

        public override void Tick()
        {
            return;
            if (Input.x != 0 && Player.PlayerJumper.GroundChecker.IsGroundedWithOutCoyote &&
                !Services.InputService.Jump)
                TryPeekDown(_playerStepper.RightRayPoint, _playerStepper.LeftRayPoint);
        }

        public void Init(PlayerStepper playerStepper)
        {
            _playerStepper = playerStepper;
        }

        private void TryPeekDown(Transform point1, Transform point2)
        {
            if (!Ray(point1, out var topPoint1)) return;
            if (!Ray(point2, out var topPoint2)) return;
            if (!Satisfies(point1, topPoint1) || !Satisfies(point2, topPoint2)) return;

            PeekDown(point1.position.y > point2.position.y ? topPoint1 : topPoint2);
        }

        private bool Ray(Transform point1, out Vector2 topPoint)
        {
            topPoint = default;

            var count = Physics2D.RaycastNonAlloc(point1.position, Vector2.down, _result, _playerStepper.MaxStep);
            if (count == 0)
                return false;

            var sec = _result.Slice(0, count)
                .OrderByDescending(x => x.point.y)
                .Where(x => !x.transform.HasComponent<PlayerTag>() && !x.collider.isTrigger)
                .ToArray();

            if (sec.Length == 0)
                return false;

            print(string.Join(",", sec.Select(x => x.transform.name)));
            topPoint = sec.First().point;
            return true;
        }

        private bool Satisfies(Transform rayPoint, Vector2 topPoint)
        {
            var delta = Math.Abs(topPoint.y - rayPoint.position.y);
            return delta >= _playerStepper.MinStep && delta <= _playerStepper.MaxStep;
        }

        private void PeekDown(Vector2 topPoint)
        {
            _playerStepper.Rb2D.position = _playerStepper.Rb2D.position
                // .WithX(_playerStepper.Rb2D.position.x - Input.x * _playerStepper.XTeleportOffset)
                .WithY(topPoint.y - _playerStepper.Player2FootsDelta);
        }
    }
}