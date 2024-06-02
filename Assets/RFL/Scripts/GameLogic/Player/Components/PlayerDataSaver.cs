namespace RFL.Scripts.GameLogic.Player.Components
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;

    public class PlayerDataSaver : MonoBeh, ISavable
    {
        public void Save()
        {
            Di.Get<RepositoryService>().GameData.playerPos.Value =
                Di.Get<Player>().Get<PlayerTransform>().Pos;
        }

        protected override void OnStart()
        {
            var playerTransformPos = Di.Get<RepositoryService>().GameData.playerPos.Value;
            Di.Get<Player>().Get<PlayerTransform>().Pos = playerTransformPos;
        }
    }
}