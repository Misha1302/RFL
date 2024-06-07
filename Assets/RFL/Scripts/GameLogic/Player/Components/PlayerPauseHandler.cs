namespace RFL.Scripts.GameLogic.Player.Components
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
            Dc.Get<PauseService>().OnPausedChanged += OnPauseChanged;
        }

        private void OnPauseChanged(bool isPaused)
        {
            if (isPaused)
            {
                _savedDirection = Dc.Get<Player>().Get<PlayerTransform>().Vel;
                Dc.Get<Player>().Get<PlayerTransform>().Freeze();
            }
            else
            {
                Dc.Get<Player>().Get<PlayerTransform>().UnFreeze();
                Dc.Get<Player>().Get<PlayerTransform>().Vel = _savedDirection;
            }
        }
    }
}