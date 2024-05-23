namespace RFL.Scripts.GameLogic.Player.Stepper
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Tags;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerUpStepper))]
    [RequireComponent(typeof(PlayerDownStepper))]
    public class PlayerStepper : MonoBeh
    {
        public static readonly ContactFilter2D ContactFilter2D;

        [SerializeField] private float minStep = 0.02f;
        [SerializeField] private float maxStep = 0.7f;
        [SerializeField] private float xOffset;
        [SerializeField] private Transform playerFoot;

        static PlayerStepper()
        {
            ContactFilter2D = new ContactFilter2D().NoFilter();
            ContactFilter2D.useTriggers = false;
        }

        public float MinStep => minStep;
        public float MaxStep => maxStep;
        public Transform PlayerFoot => playerFoot;

        public float Player2FootsDelta => -PlayerFoot.localPosition.y * Player.PlayerSingleton.transform.lossyScale.y;
        public float XOffset => xOffset;

        protected override void OnStart()
        {
            GetComponent<PlayerUpStepper>().Init(this);
            GetComponent<PlayerDownStepper>().Init(this);
        }

        public static bool RightCollider(Collider2D x) => !x.HasComponent<PlayerTag>() && !x.isTrigger;
    }
}