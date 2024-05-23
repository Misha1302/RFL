namespace RFL.Scripts.GameLogic.Lift
{
    using System;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    [RequireComponent(typeof(Collider2D))]
    public class ColliderActivator : MonoBeh
    {
        [SerializeField] private Collider2D colToActive;

        private readonly Lazy<Collider2D> _collider;
        private readonly Collider2D[] _results = new Collider2D[CollectionsLength.MaxCollisionsCount];

        public ColliderActivator()
        {
            _collider = new Lazy<Collider2D>(GetComponent<Collider2D>);
        }

        private Collider2D Collider => _collider.Value;

        protected override void FixedTick()
        {
            var count = Collider.OverlapCollider(new ContactFilter2D().NoFilter(), _results);
            var rbs = _results.Slice(0, count).Where(x => x.HasComponent<Rigidbody2D>());
            var anyRightPosition = rbs.Any(x =>
            {
                var halfYCollider = x.GetComponent<Collider2D>().bounds.extents.y;
                var bottomY = x.transform.position.y - halfYCollider;
                return bottomY >= transform.position.y;
            });
            colToActive.enabled = anyRightPosition;
        }
    }
}