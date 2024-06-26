namespace RFL.Scripts.GameLogic.Lift
{
    using RFL.Scripts.Extensions.Math.Numbers;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class LiftMovement : MonoBeh
    {
        [SerializeField] private AnimationCurve movementCurve;
        [SerializeField] private Transform aPoint;
        [SerializeField] private Transform bPoint;
        [SerializeField] private float speed = 1f;

        private float T => movementCurve.Evaluate((TimeSinceStart * speed).PingPong(1f));
        private Vector3 CurPoint => Vector3.Lerp(aPoint.position, bPoint.position, T);

        protected override void FixedTick()
        {
            transform.position = CurPoint;
        }
    }
}