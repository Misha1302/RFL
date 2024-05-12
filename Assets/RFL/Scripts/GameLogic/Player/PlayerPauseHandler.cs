namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.GameManager;
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
                _savedDirection = Rb.velocity;
                Rb.constraints = RigidbodyConstraints2D.FreezeAll;
            }
            else
            {
                Rb.constraints = RigidbodyConstraints2D.None;
                Rb.velocity = _savedDirection;
            }
        }
    }
}