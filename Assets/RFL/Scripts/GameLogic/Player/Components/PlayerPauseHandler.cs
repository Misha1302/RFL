namespace RFL.Scripts.GameLogic.Player.Components
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPauseHandler : MonoBeh, Player.IPlayerScope
    {
        [Inject] private Lazy<PauseService> _pauseService;
        [Inject] private Lazy<PlayerTransform> _playerTransform;
        [Inject] private Lazy<RepositoryService> _repositoryService;

        private Vector3 _savedDirection;

        protected override void OnStart()
        {
            _pauseService.Value.OnPausedChanged += OnPauseChanged;
        }

        private void OnPauseChanged(bool isPaused)
        {
            if (isPaused)
            {
                _savedDirection = _playerTransform.Value.Vel;
                _playerTransform.Value.Freeze();
            }
            else
            {
                _playerTransform.Value.UnFreeze();
                _playerTransform.Value.Vel = _savedDirection;
            }
        }
    }
}