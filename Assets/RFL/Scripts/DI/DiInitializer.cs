namespace RFL.Scripts.DI
{
    using RFL.Scripts.Attributes;
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

    public static class DiInitializer
    {
        [InitializerMethod(-1000)]
        public static void Initialize()
        {
            DependencyInjector.CreateSingleton(Dc.Instance);

            Dc.Instance.AddSingle(new CreatorService());
            Dc.Instance.AddSingle(new DestroyerService());
            Dc.Instance.AddSingle(new PauseService());
            Dc.Instance.AddSingle(new NextMomentExecutorService());
            Dc.Instance.AddSingle(Dc.Get<CreatorService>().Create<GameService>());
            Dc.Instance.AddSingle(Dc.Get<CreatorService>().Create<ApplicationEventsService>());

            Dc.Instance.AddSingle(new SceneService());
            Dc.Instance.AddSingle(new RepositoryService());
            Dc.Instance.AddSingle(InputMaker.MakeInputService());
            Dc.Instance.AddSingle(Dc.Get<CreatorService>().Create<TimeService>());
            Dc.Instance.AddSingle(Dc.Get<CreatorService>().Create<CoroutinesService>());
            Dc.Instance.AddSingle(Dc.Get<CreatorService>().Create<FpsCounterService>());
            Dc.Instance.AddSingle(new FpsSetterService());
        }
    }
}