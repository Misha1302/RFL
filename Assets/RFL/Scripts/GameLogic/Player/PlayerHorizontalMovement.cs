namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameManager;
    using RFL.Scripts.GlobalServices.InputManager;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerHorizontalMovement : MonoBeh
    {
        [SerializeField] private float speed = 5f;

        private static IInputManager InputManager => Di.Instance.GetGlobalSingleton<IInputManager>();


        public override void Tick()
        { 
            Rb.velocity = Rb.velocity.WithX(InputManager.Input.x * speed);
        }
    }
}