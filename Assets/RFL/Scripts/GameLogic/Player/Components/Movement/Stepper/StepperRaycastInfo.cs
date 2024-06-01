namespace RFL.Scripts.GameLogic.Player.Movement.Stepper
{
    using RFL.Scripts.Extensions;
    using UnityEngine;

    public readonly struct StepperRaycastInfo
    {
        public bool WasHit => !HitPoint.IsNan();

        public readonly Vector2 HitPoint;
        public readonly bool WasAnyHitOnPath;

        public StepperRaycastInfo(Vector2 hitPoint, bool wasAnyHitOnPath)
        {
            HitPoint = hitPoint;
            WasAnyHitOnPath = wasAnyHitOnPath;
        }
    }
}