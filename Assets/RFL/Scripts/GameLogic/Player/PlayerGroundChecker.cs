namespace RFL.Scripts.GameLogic.Player
{
    using System;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Tags;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class PlayerGroundChecker : MonoBeh
    {
        [SerializeField] private float coyoteTime = 0.2f;

        private readonly Lazy<Collider2D> _collider2D;
        private readonly ContactFilter2D _contactFilter2D = new() { useTriggers = false };
        private readonly Collider2D[] _results = new Collider2D[CollectionsLength.MaxCollisionsCount];

        private float _timeWhenIsGroundedWasTrue = float.NegativeInfinity;

        public PlayerGroundChecker()
        {
            _collider2D = new Lazy<Collider2D>(GetComponent<Collider2D>);
        }

        public bool IsGroundedWithCoyote => _timeWhenIsGroundedWasTrue + coyoteTime >= TimeSinceStart;

        public bool IsGroundedWithOutCoyote =>
            Math.Abs(_timeWhenIsGroundedWasTrue - TimeSinceStart) <= FixedDeltaTime * 2;

        private Collider2D Collider2D => _collider2D.Value;

        protected override void FixedTick()
        {
            var count = Collider2D.OverlapCollider(_contactFilter2D, _results);

            if (_results.Slice(0, count).Any(x => !x.HasComponent<NotAGroundTag>()))
                _timeWhenIsGroundedWasTrue = TimeSinceStart;
        }
    }
}