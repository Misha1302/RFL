namespace RFL.Scripts.GameLogic.Player.Movement.Stepper
{
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
        }

        public readonly Transform LeftRayPoint;
        public readonly Transform RightRayPoint;
        public readonly float XOffset;
        public readonly float MaxStep;
        public readonly float MinStep;
    }
}