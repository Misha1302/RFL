namespace RFL.Scripts.GameLogic.Player.Components
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;

    public class PlayerDataSaver : MonoBeh, ISavable
    {
        [Inject] private PlayerTransform _playerTransform;
        [Inject] private RepositoryService _repositoryService;

        public void Save()
        {
            _repositoryService.GameData.playerPos.Value =
                _playerTransform.Pos;
        }

        protected override void OnStart()
        {
            var playerTransformPos = _repositoryService.GameData.playerPos.Value;
            _playerTransform.Pos = playerTransformPos;
        }
    }
}