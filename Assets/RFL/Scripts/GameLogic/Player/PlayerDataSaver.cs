namespace RFL.Scripts.GameLogic.Player
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.ApplicationEvents;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;

    public class PlayerDataSaver : MonoBeh
    {
        protected override void OnStart()
        {
            Di.Get<ApplicationEventsService>().SubscribeOnAppQuit(() =>
            {
                Di.Get<RepositoryService>().GameData.playerPos.Value =
                    Di.Get<Player>().PlayerTransform.Pos.Round(0.5f);
            });

            Di.Get<Player>().PlayerTransform.Pos = Di.Get<RepositoryService>().GameData.playerPos.Value;
        }
    }
}