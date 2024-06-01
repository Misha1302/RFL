namespace RFL.Scripts.GameLogic.Player.Components.Movement.Stepper
{
    using System;
    using System.Linq;
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Tags;
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class PlayerStepperWorker
    {
        private readonly StepperInfo _stepperInfo;
        private readonly RaycastHit2D[] _hits = new RaycastHit2D[CollectionsLength.MaxHitsCount];


        public PlayerStepperWorker(StepperInfo stepperInfo)
        {
            _stepperInfo = stepperInfo;
        }

        public void TryWork()
        {
            if (!Di.Get<Player>().Get<PlayerJumper>().GroundChecker.IsGroundedWithOutCoyote) return;

            var castLeft = Raycast(_stepperInfo.LeftRayPoint.position);
            var castRight = Raycast(_stepperInfo.RightRayPoint.position);

            float y;
            if (castLeft.WasHit && !castRight.WasAnyHitOnPath)
                y = castLeft.HitPoint.y;
            else if (!castLeft.WasAnyHitOnPath && castRight.WasHit)
                y = castRight.HitPoint.y;
            else if (castRight.WasHit && castLeft.WasHit)
                y = castLeft.HitPoint.y.Max(castRight.HitPoint.y);
            else return;

            Di.Get<Player>().Get<PlayerTransform>().MoveToY(CalcY(y));
            Di.Get<Player>().Get<PlayerTransform>().MoveToX(
                Di.Get<Player>().Get<PlayerTransform>().Pos.x +
                Math.Sign(Di.Get<IInputService>().Input.X) * _stepperInfo.XOffset
            );
        }

        private static float CalcY(float y) => y + Di.Get<Player>().Get<PlayerStepper>().Player2FootsDelta;

        private StepperRaycastInfo Raycast(Vector3 point)
        {
            var count =
                Physics2D.Raycast(point, Vector2.down, PlayerStepper.ContactFilter2D, _hits, _stepperInfo.MaxStep);

            var hits = _hits.Slice(0, count)
                .Where(x => !x.transform.HasComponent<PlayerTag>())
                .OrderByDescending(x => x.point.y)
                .ToArray();

            var hit = hits.FirstOrDefault();
            if (point.y - hit.point.y < _stepperInfo.MinStep)
                hit = default;

            var hitPoint = hit ? hit.point : Vectors2Extensions.MakeNan();
            DrawRay(point, hitPoint);
            return new StepperRaycastInfo(hitPoint, hits.Length != 0);
        }

        private void DrawRay(Vector3 point, Vector2 end)
        {
            Debug.DrawLine(point, point + Vector3.down * _stepperInfo.MaxStep, Color.red);
            if (!end.IsNan())
                Debug.DrawLine(point, end, Color.green);
        }
    }
}