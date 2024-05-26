namespace RFL.Scripts.GameLogic.Lift
{
    using System.Collections.Generic;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class StickyPlatform : MonoBeh
    {
        private readonly Dictionary<Transform, Transform> _parentsOfTransforms = new();

        protected override void OnColEnter2D(Collision2D other)
        {
            var t = other.transform;
            if (!t.HasComponent<Rigidbody2D>()) return;

            _parentsOfTransforms[t] = t.parent;
            t.SetParent(transform);
        }

        protected override void OnColExit2D(Collision2D other)
        {
            var t = other.transform;
            if (!t.HasComponent<Rigidbody2D>()) return;

            t.SetParent(_parentsOfTransforms[t]);
        }
    }
}