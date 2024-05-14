namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerImageFlipper : MonoBeh
    {
        public override void LateTick()
        {
            Flip();
        }


        private void Flip()
        {
            if (Rb.velocity.x != 0)
                SpriteRenderer.flipX = Rb.velocity.x < 0;
        }
    }
}