namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerImageFlipper : MonoBeh
    {
        protected override void LateTick()
        {
            Flip();
        }


        private void Flip()
        {
            if (Player.PlayerTransform.Vel.x != 0)
                SpriteRenderer.flipX = Player.PlayerTransform.Vel.x < 0;
        }
    }
}