namespace RFL.Scripts.GameLogic.Player.Components
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;

    public class PlayerDataSaver : MonoBeh, ISavable, Player.IPlayerScope
    {
        [Inject] private Lazy<PlayerTransform> _playerTransform;
        [Inject] private Lazy<RepositoryService> _repositoryService;

        public void Save()
        {
            _repositoryService.Value.GameData.playerPos.Value = _playerTransform.Value.Pos;
        }

        protected override void OnStart()
        {
            var playerTransformPos = _repositoryService.Value.GameData.playerPos.Value;
            _playerTransform.Value.Pos = playerTransformPos;
        }
    }
}