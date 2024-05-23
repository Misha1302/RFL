namespace RFL.Scripts.GameLogic.Player.Stepper
{
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Tags;
    using UnityEngine;

    public class PlayerDownStepper : MonoBeh
    {
        private static readonly ContactFilter2D _contactFilter2D;
        private readonly RaycastHit2D[] _hits = new RaycastHit2D[CollectionsLength.MaxHitsCount];

        private PlayerStepper _playerStepper;

        static PlayerDownStepper()
        {
            _contactFilter2D = new ContactFilter2D().NoFilter();
            _contactFilter2D.useTriggers = false;
        }

        public void Init(PlayerStepper playerStepper)
        {
            _playerStepper = playerStepper;
        }

        public override void FixedTick()
        {
            if (!Player.PlayerJumper.GroundChecker.IsGroundedWithOutCoyote) return;

            var castLeft = Raycast(_playerStepper.LeftRayPoint.position);
            var castRight = Raycast(_playerStepper.RightRayPoint.position);

            if (castLeft.WasHit && !castRight.WasAnyHitOnPath) Player.PlayerTransform.MoveToY(castLeft.HitPoint.y);
            if (castRight.WasHit && !castLeft.WasAnyHitOnPath) Player.PlayerTransform.MoveToY(castRight.HitPoint.y);
            if (castRight.WasHit && castLeft.WasHit)
                Player.PlayerTransform.MoveToY(Mathf.Max(castLeft.HitPoint.y, castRight.HitPoint.y) + (Player.PlayerStepper.Player2FootsDelta));
        }

        private StepperRaycastInfo Raycast(Vector3 point)
        {
            var count = Physics2D.Raycast(point, Vector2.down, _contactFilter2D, _hits, _playerStepper.MaxStep);
            var hit = _hits.Slice(0, count)
                .OrderByDescending(x => x.point.y)
                .FirstOrDefault(x => point.y - x.point.y > _playerStepper.MinStep && !x.transform.HasComponent<PlayerTag>());

            Debug.DrawLine(point, point + Vector3.down * _playerStepper.MaxStep, Color.red);
            Debug.DrawLine(point, hit.point, Color.green);

            return new StepperRaycastInfo(hit ? hit.point : Vector2.zero.MakeNan(), count != 0);
        }
    }
}