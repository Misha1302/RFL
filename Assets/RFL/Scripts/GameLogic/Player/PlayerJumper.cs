namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJumper : MonoBeh
    {
        [SerializeField] private AnimationCurve jumpVelocityCurve;
        [SerializeField] private float jumpTime = 0.75f;
        [SerializeField] private float jumpHeight = 8f;

        private bool _jumped;
        private float _startJumpTime = float.MinValue;


        private bool IsJumping => jumpTime >= PassedTime
                                  && Services.InputService.Jump
                                  && !GroundChecker.IsGroundedWithOutCoyote;


        private float PassedTime => Time - _startJumpTime;

        public PlayerGroundChecker GroundChecker { get; private set; }


        public override void OnStart()
        {
            GroundChecker = GetComponentInChildren<PlayerGroundChecker>();
        }

        public override void Tick()
        {
            HandleJumpIfNeed();
            HandleJumpingIfNeed();
            HandleEndOfJumpingIfNeed();
        }

        private void HandleJumpIfNeed()
        {
            if (jumpTime >= PassedTime || !Services.InputService.Jump || !GroundChecker.IsGroundedWithCoyote) return;
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
            Rb.AddForce(Vector2.up * (GetYForce() * UnityEngine.Time.deltaTime));
        }

        private void HandleJump()
        {
            _startJumpTime = Time;
            _jumped = true;

            Rb.velocity = Rb.velocity.WithY(GetYForce());
        }

        private void HandleEndOfJumping()
        {
            _jumped = false;
            _startJumpTime = float.MinValue;

            SlowDownIfNeed();
        }

        private void SlowDownIfNeed()
        {
            if (Rb.velocity.y <= 0) return;
            SlowDown();
        }

        private void SlowDown()
        {
            Rb.velocity = Rb.velocity.WithY(Rb.velocity.y / 2f);
        }

        private float GetYForce() => jumpVelocityCurve.Evaluate(PassedTime / jumpTime) * jumpHeight;
    }
}