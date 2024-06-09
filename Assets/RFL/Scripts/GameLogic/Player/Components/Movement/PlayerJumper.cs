namespace RFL.Scripts.GameLogic.Player.Components.Movement
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJumper : MonoBeh, Player.IPlayerScope
    {
        [SerializeField] private AnimationCurve jumpVelocityCurve;
        [SerializeField] private float jumpTime = 0.75f;
        [SerializeField] private float jumpHeight = 10f;

        [Inject] private IInputService _inputService;
        private bool _jumped;
        [Inject] private PlayerTransform _playerTransform;
        private float _startJumpTime = float.MinValue;


        private bool IsJumping =>
            jumpTime >= PassedTime && _inputService.Jump && !GroundChecker.IsGroundedWithOutCoyote;


        private float PassedTime => TimeSinceStart - _startJumpTime;

        public PlayerGroundChecker GroundChecker { get; private set; }


        protected override void OnStart()
        {
            GroundChecker = GetComponentInChildren<PlayerGroundChecker>();
        }

        protected override void Tick()
        {
            HandleJumpIfNeed();
            HandleJumpingIfNeed();
            HandleEndOfJumpingIfNeed();
        }

        private void HandleJumpIfNeed()
        {
            if (jumpTime >= PassedTime || !_inputService.Jump || !GroundChecker.IsGroundedWithCoyote) return;
            HandleJump();
        }

        private void HandleEndOfJumpingIfNeed()
        {
            if (IsJumping || !_jumped) return;
            HandleEndOfJumping();
        }

        private void HandleJumpingIfNeed()
        {
            if (!IsJumping) return;
            HandleJumping();
        }

        private void HandleJumping()
        {
            _playerTransform.AddForce(Vector2.up * (GetYForce() * DeltaTime));
        }

        private void HandleJump()
        {
            _startJumpTime = TimeSinceStart;
            _jumped = true;

            _playerTransform.SetVelocityY(GetYForce());
        }

        private void HandleEndOfJumping()
        {
            _jumped = false;
            _startJumpTime = float.MinValue;

            SlowDownIfNeed();
        }

        private void SlowDownIfNeed()
        {
            if (_playerTransform.Vel.y <= 0) return;
            SlowDown();
        }

        private void SlowDown()
        {
            _playerTransform.SetVelocityY(_playerTransform.Vel.y / 2f);
        }

        private float GetYForce() => jumpVelocityCurve.Evaluate(PassedTime / jumpTime) * jumpHeight;
    }
}