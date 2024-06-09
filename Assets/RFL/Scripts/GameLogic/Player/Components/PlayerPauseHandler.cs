namespace RFL.Scripts.GameLogic.Player.Components
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPauseHandler : MonoBeh, Player.IPlayerScope
    {
        [Inject] private PauseService _pauseService;
        [Inject] private PlayerTransform _playerTransform;
        [Inject] private RepositoryService _repositoryService;

        private Vector3 _savedDirection;

        protected override void OnStart()
        {
            _pauseService.OnPausedChanged += OnPauseChanged;
        }

        private void OnPauseChanged(bool isPaused)
        {
            if (isPaused)
            {
                _savedDirection = _playerTransform.Vel;
                _playerTransform.Freeze();
            }
            else
            {
                _playerTransform.UnFreeze();
                _playerTransform.Vel = _savedDirection;
            }
        }
    }
}