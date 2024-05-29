namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPauseHandler : MonoBeh
    {
        private Vector3 _savedDirection;

        protected override void OnStart()
        {
            Di.Get<PauseService>().OnPausedChanged += OnPauseChanged;
        }

        private void OnPauseChanged(bool isPaused)
        {
            if (isPaused)
            {
                _savedDirection = Di.Get<Player>().PlayerTransform.Vel;
                Di.Get<Player>().PlayerTransform.Freeze();
            }
            else
            {
                Di.Get<Player>().PlayerTransform.UnFreeze();
                Di.Get<Player>().PlayerTransform.Vel = _savedDirection;
            }
        }
    }
}