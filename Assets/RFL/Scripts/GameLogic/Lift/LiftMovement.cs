namespace RFL.Scripts.GameLogic.Lift
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class LiftMovement : MonoBeh
    {
        [SerializeField] private AnimationCurve movementCurve;
        [SerializeField] private Transform aPoint;
        [SerializeField] private Transform bPoint;
        [SerializeField] private float speed = 0.2f;

        private Vector3 CurPoint => Vector3.Lerp(aPoint.position, bPoint.position, T);
        private float T => movementCurve.Evaluate((Time * speed).PingPong(1f));

        protected override void Tick()
        {
            transform.position = CurPoint;
        }
    }
}