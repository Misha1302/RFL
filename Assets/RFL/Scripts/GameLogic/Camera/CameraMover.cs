namespace RFL.Scripts.GameLogic.Camera
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Services;
    using UnityEngine;

    public class CameraMover : MonoBeh
    {
        [SerializeField] private Transform cameraFollowPoint;

        private Vector3 _stdPosition;

        protected override void OnStart()
        {
            _stdPosition = cameraFollowPoint.localPosition;
        }

        protected override void FixedTick()
        {
            cameraFollowPoint.localPosition = _stdPosition + Dc.Get<IInputService>().Input;
        }
    }
}