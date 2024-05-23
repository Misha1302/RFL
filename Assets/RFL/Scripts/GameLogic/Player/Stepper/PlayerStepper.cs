namespace RFL.Scripts.GameLogic.Player.Stepper
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerStepper : MonoBeh
    {
        public static readonly ContactFilter2D ContactFilter2D;

        [SerializeField] private float minStep = 0.02f;
        [SerializeField] private float maxStep = 0.7f;
        [SerializeField] private float xOffset;
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

        public float MinStep => minStep;
        public float MaxStep => maxStep;

        public float Player2FootsDelta => -playerFoot.localPosition.y * Player.PlayerSingleton.transform.lossyScale.y;
        public float XOffset => xOffset;

        protected override void OnStart()
        {
            _stepperDown = new PlayerStepperWorker();
            _stepperUp = new PlayerStepperWorker();

            _stepperDown.Init(this, leftDownRayPoint, rightDownRayPoint);
            _stepperUp.Init(this, leftUpRayPoint, rightUpRayPoint);
        }

        protected override void FixedTick()
        {
            _stepperDown.TryWork();
            _stepperUp.TryWork();
        }
    }
}