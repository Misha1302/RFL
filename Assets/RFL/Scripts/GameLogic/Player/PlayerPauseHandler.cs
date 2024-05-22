namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPauseHandler : MonoBeh
    {
        private Vector3 _savedDirection;

        public override void OnStart()
        {
            Services.PauseService.OnPausedChanged += OnPauseChanged;
        }

        private void OnPauseChanged(bool isPaused)
        {
            if (isPaused)
            {
                _savedDirection = Player.PlayerTransform.Vel;
                Player.PlayerTransform.Freeze();
            }
            else
            {
                Player.PlayerTransform.UnFreeze();
                Player.PlayerTransform.Vel = _savedDirection;
            }
        }
    }
}