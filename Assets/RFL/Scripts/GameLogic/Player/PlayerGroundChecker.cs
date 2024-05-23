namespace RFL.Scripts.GameLogic.Player
{
    using System;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Tags;
    using UnityEngine;

    public class PlayerGroundChecker : MonoBeh
    {
        [SerializeField] private float coyoteTime = 0.2f;

        private readonly ContactFilter2D _contactFilter2D = new() { useTriggers = false };
        private readonly Collider2D[] _results = new Collider2D[CollectionsLength.MaxCollisionsCount];

        private float _timeWhenIsGroundedWasTrue = float.NegativeInfinity;

        public bool IsGroundedWithCoyote => _timeWhenIsGroundedWasTrue + coyoteTime >= Time;

        public bool IsGroundedWithOutCoyote =>
            Math.Abs(_timeWhenIsGroundedWasTrue - Time) <= TimeService.FixedDeltaTime * 2;


        public override void FixedTick()
        {
            var count = GetComponent<BoxCollider2D>().OverlapCollider(_contactFilter2D, _results);

            if (_results.Any(x => !x.HasComponent<NotAGroundTag>(), count))
                _timeWhenIsGroundedWasTrue = Time;
        }
    }
}