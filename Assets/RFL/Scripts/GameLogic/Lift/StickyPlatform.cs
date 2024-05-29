namespace RFL.Scripts.GameLogic.Lift
{
    using System.Collections.Generic;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class StickyPlatform : MonoBeh
    {
        private readonly Dictionary<Transform, Transform> _parentsOfTransforms = new();

        protected override void OnCreated()
        {
            CollisionDetector.OnTrigEnter2D += OnTrigEnter2D;
            CollisionDetector.OnTrigExit2D += OnTrigExit2D;
        }

        private void OnTrigEnter2D(Collider2D other)
        {
            var t = other.transform;
            if (!t.HasComponent<Rigidbody2D>()) return;

            _parentsOfTransforms[t] = t.parent;
            t.SetParent(transform);
        }


        private void OnTrigExit2D(Collider2D other)
        {
            var t = other.transform;
            if (!t.HasComponent<Rigidbody2D>()) return;

            t.SetParent(_parentsOfTransforms[t]);
        }
    }
}