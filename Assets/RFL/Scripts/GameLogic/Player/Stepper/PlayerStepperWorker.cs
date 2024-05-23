namespace RFL.Scripts.GameLogic.Player.Stepper
{
    using System;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Tags;
    using UnityEngine;

    public class PlayerStepperWorker
    {
        private readonly RaycastHit2D[] _hits = new RaycastHit2D[CollectionsLength.MaxHitsCount];
        private Transform _leftRayPoint;

        private PlayerStepper _playerStepper;
        private Transform _rightRayPoint;

        public void Init(PlayerStepper playerStepper, Transform leftRayPoint, Transform rightRayPoint)
        {
            _playerStepper = playerStepper;
            _leftRayPoint = leftRayPoint;
            _rightRayPoint = rightRayPoint;
        }

        public void TryWork()
        {
            if (!Player.PlayerJumper.GroundChecker.IsGroundedWithOutCoyote) return;

            var castLeft = Raycast(_leftRayPoint.position);
            var castRight = Raycast(_rightRayPoint.position);

            float y;
            if (castLeft.WasHit && !castRight.WasAnyHitOnPath)
                y = castLeft.HitPoint.y;
            else if (!castLeft.WasAnyHitOnPath && castRight.WasHit)
                y = castRight.HitPoint.y;
            else if (castRight.WasHit && castLeft.WasHit)
                y = Mathf.Max(castLeft.HitPoint.y, castRight.HitPoint.y);
            else return;

            Player.PlayerTransform.MoveToY(CalcY(y));
            Player.PlayerTransform.MoveToX(Player.PlayerTransform.Pos.x +
                                           Math.Sign(Services.InputService.Input.X) * _playerStepper.XOffset);
        }

        private static float CalcY(float y) => y + Player.PlayerStepper.Player2FootsDelta;

        private StepperRaycastInfo Raycast(Vector3 point)
        {
            var count =
                Physics2D.Raycast(point, Vector2.down, PlayerStepper.ContactFilter2D, _hits, _playerStepper.MaxStep);

            var hits = _hits.Slice(0, count)
                .Where(x => !x.transform.HasComponent<PlayerTag>())
                .OrderByDescending(x => x.point.y)
                .ToArray();

            var hit = hits.FirstOrDefault();
            if (point.y - hit.point.y < _playerStepper.MinStep)
                hit = default;

            DrawDownStepper(point, hit);

            return new StepperRaycastInfo(hit ? hit.point : Vectors2Extensions.MakeNan(), hits.Length != 0);
        }

        private void DrawDownStepper(Vector3 point, RaycastHit2D hit)
        {
            Debug.DrawLine(point, point + Vector3.down * _playerStepper.MaxStep, Color.red);
            Debug.DrawLine(point, hit.point, Color.green);
        }
    }
}