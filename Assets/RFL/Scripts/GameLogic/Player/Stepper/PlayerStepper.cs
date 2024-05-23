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
        [SerializeField] private float minStep = 0.02f;
        [SerializeField] private float maxStep = 1f;
        [SerializeField] private float xTeleportOffset = 0.03f;
        [SerializeField] private Transform playerFoot;
        [SerializeField] private Transform leftRayPoint;
        [SerializeField] private Transform rightRayPoint;

        public float XTeleportOffset => xTeleportOffset;
        public float MinStep => minStep;
        public float MaxStep => maxStep;
        public Transform PlayerFoot => playerFoot;
        public Transform LeftRayPoint => leftRayPoint;
        public Transform RightRayPoint => rightRayPoint;

        public float Player2FootsDelta => -PlayerFoot.localPosition.y * Player.PlayerSingleton.transform.lossyScale.y;

        public override void OnStart()
        {
            GetComponent<PlayerUpStepper>().Init(this);
            GetComponent<PlayerDownStepper>().Init(this);
        }

        public static bool RightCollider(Collider2D x) => !x.HasComponent<PlayerTag>() && !x.isTrigger;
    }
}