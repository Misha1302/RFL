namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using System;
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        private readonly Lazy<Rigidbody2D> _lazyRb;
        private readonly Lazy<SpriteRenderer> _spriteRenderer;

        protected ComponentsKeeper()
        {
            _lazyRb = new Lazy<Rigidbody2D>(GetComponent<Rigidbody2D>);
            _spriteRenderer = new Lazy<SpriteRenderer>(GetComponent<SpriteRenderer>);
        }

        protected static float Time => Services.TimeService.Time;

        protected Rigidbody2D Rb => _lazyRb.Value;
        protected SpriteRenderer SpriteRenderer => _spriteRenderer.Value;
    }
}