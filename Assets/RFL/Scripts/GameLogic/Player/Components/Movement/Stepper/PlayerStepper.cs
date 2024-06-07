namespace RFL.Scripts.GameLogic.Player.Components.Movement.Stepper
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions.Math.Numbers;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerStepper : MonoBeh
    {
        public static readonly ContactFilter2D ContactFilter2D;

        [SerializeField] private float minStep = 0.05f;
        [SerializeField] private float maxStep = 0.7f;
        [SerializeField] private float xOffset = 0.05f;
        [SerializeField] private Transform playerFoot;

        [SerializeField] private Transform leftDownRayPoint;
        [SerializeField] private Transform rightDownRayPoint;

        [SerializeField] private Transform leftUpRayPoint;
        [SerializeField] private Transform rightUpRayPoint;

        private PlayerStepperWorker _stepperDown;
        private PlayerStepperWorker _stepperUp;

        static PlayerStepper()
        {
            ContactFilter2D = new ContactFilter2D().NoFilter();
            ContactFilter2D.useTriggers = false;
        }

        public float Player2FootsDelta =>
            playerFoot.localPosition.y.Abs() * Dc.Get<Player>().transform.lossyScale.y;


        protected override void OnStart()
        {
            _stepperDown = new PlayerStepperWorker(
                new StepperInfo(leftDownRayPoint, rightDownRayPoint, xOffset, maxStep, minStep)
            );
            _stepperUp = new PlayerStepperWorker(
                new StepperInfo(leftUpRayPoint, rightUpRayPoint, xOffset, maxStep, minStep)
            );
        }

        protected override void FixedTick()
        {
            _stepperDown.TryWork();
            _stepperUp.TryWork();
        }
    }
}