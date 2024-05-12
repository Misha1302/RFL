namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameManager;
    using RFL.Scripts.GlobalServices.InputManager;
    using RFL.Scripts.GlobalServices.Time;
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
        private float _timeOffset;


        private bool IsJumping =>
            _startJumpTime + jumpTime >= Time && InputManager.Jump && !_playerGroundChecker.IsGrounded;

        private static IInputManager InputManager => Di.Instance.GetGlobalSingleton<IInputManager>();
        private static float Time => Di.Instance.GetGlobalSingleton<GlobalTime>().Time;
        private float PassedTime => Time - _startJumpTime + _timeOffset;


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
            if (_startJumpTime + jumpTime < Time && InputManager.Jump && _playerGroundChecker.IsGrounded)
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

            // set velocity at first time to remove error with fast acceleration
            if (PassedTime < 0.1f) Rb.velocity = Rb.velocity.WithY(GetYForce());
            else Rb.AddForce(Vector2.up * GetYForce());
        }

        private void Jump()
        {
            _startJumpTime = Time;
            Rb.velocity = Rb.velocity.WithY(GetYForce());
        }

        private float GetYForce() => jumpVelocityCurve.Evaluate(PassedTime / jumpTime) * jumpHeight;
    }
}