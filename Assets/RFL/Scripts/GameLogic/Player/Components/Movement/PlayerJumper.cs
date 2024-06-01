namespace RFL.Scripts.GameLogic.Player.Movement
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJumper : MonoBeh
    {
        [SerializeField] private AnimationCurve jumpVelocityCurve;
        [SerializeField] private float jumpTime = 0.75f;
        [SerializeField] private float jumpHeight = 10f;

        private bool _jumped;
        private float _startJumpTime = float.MinValue;


        private bool IsJumping =>
            jumpTime >= PassedTime && Di.Get<IInputService>().Jump && !GroundChecker.IsGroundedWithOutCoyote;


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
            if (jumpTime >= PassedTime || !Di.Get<IInputService>().Jump || !GroundChecker.IsGroundedWithCoyote) return;
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
            Di.Get<Player>().Get<PlayerTransform>().AddForce(Vector2.up * (GetYForce() * DeltaTime));
        }

        private void HandleJump()
        {
            _startJumpTime = TimeSinceStart;
            _jumped = true;

            Di.Get<Player>().Get<PlayerTransform>().SetVelocityY(GetYForce());
        }

        private void HandleEndOfJumping()
        {
            _jumped = false;
            _startJumpTime = float.MinValue;

            SlowDownIfNeed();
        }

        private static void SlowDownIfNeed()
        {
            if (Di.Get<Player>().Get<PlayerTransform>().Vel.y <= 0) return;
            SlowDown();
        }

        private static void SlowDown()
        {
            Di.Get<Player>().Get<PlayerTransform>()
                .SetVelocityY(Di.Get<Player>().Get<PlayerTransform>().Vel.y / 2f);
        }

        private float GetYForce() => jumpVelocityCurve.Evaluate(PassedTime / jumpTime) * jumpHeight;
    }
}