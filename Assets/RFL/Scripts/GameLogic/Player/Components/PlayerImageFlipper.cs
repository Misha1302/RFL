namespace RFL.Scripts.GameLogic.Player.Components
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerImageFlipper : MonoBeh
    {
        [Inject] private PlayerTransform _playerTransform;

        private SpriteRenderer _spriteRenderer;

        protected override void OnStart()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        protected override void LateTick()
        {
            Flip();
        }

        private void Flip()
        {
            _spriteRenderer.flipX = _playerTransform.Vel.x switch
            {
                < 0 => true,
                > 0 => false,
                _ => _spriteRenderer.flipX
            };
        }
    }
}