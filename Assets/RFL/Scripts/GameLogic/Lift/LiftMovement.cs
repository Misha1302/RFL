namespace RFL.Scripts.GameLogic.Lift
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class LiftMovement : MonoBeh
    {
        [SerializeField] private AnimationCurve movementCurve;
        [SerializeField] private Transform aPoint;
        [SerializeField] private Transform bPoint;
        [SerializeField] private float speed;

        private Vector3 CurPoint => Vector3.Lerp(aPoint.position, bPoint.position, T);
        private float T => movementCurve.Evaluate(Mathf.PingPong(Time * speed, 1f));

        public override void Tick()
        {
            transform.position = CurPoint;
        }
    }
}