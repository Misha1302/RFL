namespace RFL.Scripts.GameLogic
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameManager;
    using RFL.Scripts.GlobalServices.InputManager;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class Player : MonoBeh
    {
        [SerializeField] private float speed;

        public override void Tick()
        {
            Rb.velocity = Rb.velocity.WithX(Di.Instance.GetGlobalSingleton<IInputManager>().Input.x * speed);
            Flip();
        }

        private void Flip()
        {
            SpriteRenderer.flipX = Rb.velocity.x < 0;
        }
    }
}