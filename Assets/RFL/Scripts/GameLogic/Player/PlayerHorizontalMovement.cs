namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHorizontalMovement : MonoBeh
    {
        [SerializeField] private float speed = 5f;


        public override void Tick()
        {
            Player.PlayerTransform.SetVelocityX(Services.InputService.Input.X * speed);
        }
    }
}