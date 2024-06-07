namespace RFL.Scripts.GameLogic.Player.Components.Movement
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHorizontalMovement : MonoBeh
    {
        [SerializeField] private float speed = 5f;

        [InjectMethod]
        public void Init(IInputService inputService)
        {
            
        }

        protected override void Tick()
        {
            Dc.Get<Player>().Get<PlayerTransform>().SetVelocityX(Dc.Get<IInputService>().Input.X * speed);
        }
    }
}