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
            Di.Instance.AddSingle(new PauseService());
            Di.Instance.AddSingle(Creator.Create<GameService>());
            Di.Instance.AddSingle(Creator.Create<ApplicationEventsService>());

            Di.Instance.AddSingle(new SceneService());
            Di.Instance.AddSingle(new RepositoryService());
            Di.Instance.AddSingle(InputMaker.MakeInputService());
            Di.Instance.AddSingle(Creator.Create<TimeService>());
            Di.Instance.AddSingle(Creator.Create<CoroutinesService>());
            Di.Instance.AddSingle(Creator.Create<FpsCounterService>());

            InitializersManager.InitEvery();
        }
    }
}