namespace RFL.Scripts.GameLogic.Player.Movement
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHorizontalMovement : MonoBeh
    {
        [SerializeField] private float speed = 5f;


        protected override void Tick()
        {
            Di.Get<Player>().Get<PlayerTransform>().SetVelocityX(Di.Get<IInputService>().Input.X * speed);
        }
    }
}