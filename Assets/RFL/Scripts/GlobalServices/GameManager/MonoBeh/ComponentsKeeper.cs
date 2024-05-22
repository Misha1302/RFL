namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using System;
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        private readonly Lazy<SpriteRenderer> _spriteRenderer;

        protected ComponentsKeeper()
        {
            _spriteRenderer = new Lazy<SpriteRenderer>(GetComponent<SpriteRenderer>);
        }

        protected static float Time => Services.TimeService.TotalTime;
        protected SpriteRenderer SpriteRenderer => _spriteRenderer.Value;
    }
}