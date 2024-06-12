namespace RFL.Scripts.DependenciesManagement
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GameLogic.Scenes;
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
    using RFL.Scripts.Singletons;

    public class DiInitializer
    {
        [SceneInitializer(typeof(AnyScene), -1000, InitializationType.Once)]
        public void Initialize()
        {
            var creator = new CreatorService();
            var container = GameSingletons.DependencyInjector.DependencyContainer;

            container.AddSingle(creator);
            container.AddSingle(new DestroyerService());
            container.AddSingle(creator.Create<ApplicationEventsService>());
            container.AddSingle(new PauseService());
            container.AddSingle(new NextMomentExecutorService());
            container.AddSingle(new RepositoryService());
            container.AddSingle(new TimeService());
            container.AddSingle(creator.Create<GameService>());
            container.AddSingle(creator.Create<TimeManagerService>());

            container.AddSingle(new SceneService());
            container.AddSingle(InputMaker.MakeInputService(creator));
            container.AddSingle(creator.Create<CoroutinesService>());
            container.AddSingle(creator.Create<FpsCounterService>());
            container.AddSingle(new FpsSetterService());
        }
    }
}