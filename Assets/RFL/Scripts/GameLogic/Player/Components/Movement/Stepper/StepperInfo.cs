namespace RFL.Scripts.GameLogic.Player.Components.Movement.Stepper
{
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public readonly struct StepperInfo
    {
        public StepperInfo(Transform leftRayPoint, Transform rightRayPoint, float xOffset, float maxStep, float minStep)
        {
            LeftRayPoint = leftRayPoint;
            RightRayPoint = rightRayPoint;
            XOffset = xOffset;
            MaxStep = maxStep;
            MinStep = minStep;

            HitsBuffer = new RaycastHit2D[CollectionsLength.MaxHitsCount];
        }

        public readonly Transform LeftRayPoint;
        public readonly Transform RightRayPoint;
        public readonly float XOffset;
        public readonly float MaxStep;
        public readonly float MinStep;

        public readonly RaycastHit2D[] HitsBuffer;
    }
}