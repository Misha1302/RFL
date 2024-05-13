namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameManager;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Tags;
    using UnityEngine;

    public class PlayerGroundChecker : MonoBeh
    {
        [SerializeField] private float coyoteTime = 0.2f;

        private readonly ContactFilter2D _contactFilter2D = new() { useTriggers = false };
        private readonly Collider2D[] _results = new Collider2D[CollisionsManager.MaxCollisionsCount];

        private float _timeWhenIsGroundedWasTrue = float.NegativeInfinity;

        public bool IsGrounded => _timeWhenIsGroundedWasTrue + coyoteTime >= Time;

        private static float Time => Services.TimeService.Time;

        public override void FixedTick()
        {
            var count = GetComponent<BoxCollider2D>().OverlapCollider(_contactFilter2D, _results);

            if (_results.Any(x => !x.HasComponent<NotAGroundTag>(), count))
                _timeWhenIsGroundedWasTrue = Time;
        }
    }
}