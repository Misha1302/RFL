namespace RFL.Scripts.GameLogic.Player
{
    using System;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerImageFlipper : MonoBeh
    {
        private readonly Lazy<SpriteRenderer> _spriteRenderer;

        protected PlayerImageFlipper()
        {
            _spriteRenderer = new Lazy<SpriteRenderer>(GetComponent<SpriteRenderer>);
        }

        protected override void LateTick()
        {
            Flip();
        }

        private void Flip()
        {
            if (Player.PlayerTransform.Vel.x != 0)
                _spriteRenderer.Value.flipX = Player.PlayerTransform.Vel.x < 0;
        }
    }
}