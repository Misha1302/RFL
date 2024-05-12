﻿namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameManager;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJumper : MonoBeh
    {
        [SerializeField] private AnimationCurve jumpVelocityCurve;
        [SerializeField] private float jumpTime = 1;
        [SerializeField] private float jumpHeight = 10;

        private bool _jumped;
        private PlayerGroundChecker _playerGroundChecker;
        private float _startJumpTime = float.MinValue;


        private bool IsJumping =>
            _startJumpTime + jumpTime >= Services.TimeService.Time && Services.InputService.Jump &&
            !_playerGroundChecker.IsGrounded;

        private float PassedTime => Services.TimeService.Time - _startJumpTime;


        public override void OnStart()
        {
            _playerGroundChecker = GetComponentInChildren<PlayerGroundChecker>();
        }

        public override void Tick()
        {
            HandleJumpIfNeed();
            HandleJumpingIfNeed();
            HandleEndOfJumpingIfNeed();
        }

        private void HandleJumpIfNeed()
        {
            if (_startJumpTime + jumpTime < Services.TimeService.Time && Services.InputService.Jump &&
                _playerGroundChecker.IsGrounded)
                Jump();
        }

        private void HandleEndOfJumpingIfNeed()
        {
            if (IsJumping || !_jumped) return;

            _jumped = false;
            _startJumpTime = float.MinValue;

            SlowDownIfNeed();
        }

        private void SlowDownIfNeed()
        {
            if (Rb.velocity.y > 0)
                Rb.velocity = Rb.velocity.WithY(Rb.velocity.y / 2f);
        }

        private void HandleJumpingIfNeed()
        {
            if (!IsJumping) return;

            _jumped = true;

            // set velocity when grounded to remove error with fast acceleration
            if (_playerGroundChecker.IsGrounded) Rb.velocity = Rb.velocity.WithY(GetYForce());
            else Rb.AddForce(Vector2.up * GetYForce());
        }

        private void Jump()
        {
            _startJumpTime = Services.TimeService.Time;
            Rb.velocity = Rb.velocity.WithY(GetYForce());
        }

        private float GetYForce() => jumpVelocityCurve.Evaluate(PassedTime / jumpTime) * jumpHeight;
    }
}