namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameManager;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Tags;
    using UnityEngine;

    public class PlayerGroundChecker : MonoBeh
    {
        private readonly ContactFilter2D _contactFilter2D = new() { useTriggers = false };
        private readonly Collider2D[] _results = new Collider2D[CollisionsManager.MaxCollisionsCount];

        public bool IsGrounded { get; private set; }


        public override void Tick()
        {
            var count = GetComponent<BoxCollider2D>().OverlapCollider(_contactFilter2D, _results);

            IsGrounded = _results.Any(x => !x.TryGetComponent<NotAGroundTag>(out _), count);
        }
    }
}