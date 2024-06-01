namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;

    public class PlayerDataSaver : MonoBeh, ISavable
    {
        public void Save()
        {
            Di.Get<RepositoryService>().GameData.playerPos.Value =
                Di.Get<Player>().Get<PlayerTransform>().Pos.Round(0.5f);
        }

        protected override void OnStart()
        {
            var playerTransformPos = Di.Get<RepositoryService>().GameData.playerPos.Value;
            Di.Get<Player>().Get<PlayerTransform>().Pos = playerTransformPos;
        }
    }
}