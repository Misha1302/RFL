namespace RFL.Scripts.GameLogic.Player.Movement
{
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
            Player.PlayerTransform.AddForce(Vector2.up * (GetYForce() * UnityEngine.Time.deltaTime));
        }

        private void HandleJump()
        {
            _startJumpTime = Time;
            _jumped = true;

            Player.PlayerTransform.SetVelocityY(GetYForce());
        }

        private void HandleEndOfJumping()
        {
            _jumped = false;
            _startJumpTime = float.MinValue;

            SlowDownIfNeed();
        }

        private void SlowDownIfNeed()
        {
            if (Player.PlayerTransform.Vel.y <= 0) return;
            SlowDown();
        }

        private void SlowDown()
        {
            Player.PlayerTransform.SetVelocityY(Player.PlayerTransform.Vel.y / 2f);
        }

        private float GetYForce() => jumpVelocityCurve.Evaluate(PassedTime / jumpTime) * jumpHeight;
    }
}