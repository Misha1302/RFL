namespace RFL.Scripts.GameLogic.Player
{
    using System;
    using System.Linq;
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class PlayerUpStepper : MonoBeh
    {
        private PlayerStepper _playerStepper;

        public void Init(PlayerStepper playerStepper)
        {
            _playerStepper = playerStepper;
        }

        public override void OnColStay2D(Collision2D other)
        {
            if (!Player.PlayerJumper.GroundChecker.IsGroundedWithOutCoyote)
                return;

            var point = other.contacts
                .OrderByDescending(x => x.point.y)
                .FirstOrDefault(x => PlayerStepper.RightCollider(x.collider))
                .point;

            if (point == default)
                return;

            TryPickUp(point);
        }

        private void TryPickUp(Vector2 point)
        {
            if (InputDirection() == PointDirection(point) && IsFeasibleHeight(point))
                PickUpPlayer(point);
        }

        private void PickUpPlayer(Vector2 point)
        {
            var t = Player.PlayerTransform;
            t.MoveToX(t.Pos.x - InputDirection() * _playerStepper.XTeleportOffset);
            t.MoveToY(point.y - _playerStepper.Player2FootsDelta);
        }

        private bool IsFeasibleHeight(Vector2 point)
        {
            var delta = point.y - _playerStepper.PlayerFoot.position.y;
            return delta >= _playerStepper.MinStep && delta <= _playerStepper.MaxStep;
        }

        private static int InputDirection() => Math.Sign(-Services.InputService.Input.X);

        private int PointDirection(Vector2 point) => Math.Sign(transform.position.x - point.x);
    }
}