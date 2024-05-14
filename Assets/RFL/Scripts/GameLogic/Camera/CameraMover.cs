namespace RFL.Scripts.GameLogic.Camera
{
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class CameraMover : MonoBeh
    {
        [SerializeField] private Transform cameraFollowPoint;

        private Vector3 _stdPosition;

        public override void OnStart()
        {
            _stdPosition = cameraFollowPoint.localPosition;
        }

        public override void FixedTick()
        {
            cameraFollowPoint.localPosition = _stdPosition + (Vector3)Services.InputService.Input;
        }
    }
}