namespace RFL.Scripts.Bootstrap
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.ApplicationEvents;
    using RFL.Scripts.GlobalServices.Coroutines;
    using RFL.Scripts.GlobalServices.Fps;
    using RFL.Scripts.GlobalServices.GameManager;
    using RFL.Scripts.GlobalServices.Input;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.GlobalServices.Scenes;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;

    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            Di.Instance.AddGlobalSingleton(new PauseService());
            Di.Instance.AddGlobalSingleton(Creator.Create<GameService>());
            Di.Instance.AddGlobalSingleton(Creator.Create<ApplicationEventsService>());

            Di.Instance.AddGlobalSingleton(new SceneService());
            Di.Instance.AddGlobalSingleton(new RepositoryService());
            Di.Instance.AddGlobalSingleton(InputMaker.MakeInputService());
            Di.Instance.AddGlobalSingleton(Creator.Create<TimeService>());
            Di.Instance.AddGlobalSingleton(Creator.Create<CoroutinesService>());
            Di.Instance.AddGlobalSingleton(Creator.Create<FpsCounterService>());

            InitializersManager.InitEvery();
        }
    }
}