namespace RFL.Scripts.GameLogic.Player
{
    using System;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class PlayerUpStepper : MonoBeh
    {
        private const float StepEpsilon = 0.01f;

        private PlayerStepper _playerStepper;

        public void Init(PlayerStepper playerStepper)
        {
            _playerStepper = playerStepper;
        }

        public override void OnColStay2D(Collision2D other)
        {
            if (!Player.PlayerJumper.GroundChecker.IsGrounded)
                return;

            var point = other.contacts.OrderByDescending(x => x.point.y).First().point;
            TryPickUp(point);
        }

        private void TryPickUp(Vector2 point)
        {
            if (InputDirection() == PointDirection(point) && IsFeasibleHeight(point))
                PickUpPlayer(point);
        }

        private void PickUpPlayer(Vector2 point)
        {
            _playerStepper.Rb2D.position = _playerStepper.Rb2D.position
                .WithX(_playerStepper.Rb2D.position.x - InputDirection() * 0.01f)
                .WithY(point.y + (transform.position.y - _playerStepper.PlayerFoot.position.y));
        }

        private bool IsFeasibleHeight(Vector2 point)
        {
            var delta = point.y - _playerStepper.PlayerFoot.position.y;
            return delta < _playerStepper.MaxStep && delta > StepEpsilon;
        }

        private static int InputDirection() => Math.Sign(-Services.InputService.Input.x);

        private int PointDirection(Vector2 point) => Math.Sign(transform.position.x - point.x);
    }
}