namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GameManager;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerUpStepper))]
    public class PlayerStepper : MonoBeh
    {
        [SerializeField] private float maxStep = 1f;
        [SerializeField] private Transform playerFoot;

        public float MaxStep => maxStep;
        public Transform PlayerFoot => playerFoot;
        public Rigidbody2D Rb2D => Rb;

        public override void OnStart()
        {
            GetComponent<PlayerUpStepper>().Init(this);
        }
    }
}