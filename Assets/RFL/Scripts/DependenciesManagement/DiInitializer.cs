namespace RFL.Scripts.DependenciesManagement
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.ApplicationEvents;
    using RFL.Scripts.GlobalServices.Coroutines;
    using RFL.Scripts.GlobalServices.Fps;
    using RFL.Scripts.GlobalServices.GameManager;
    using RFL.Scripts.GlobalServices.Input;
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.GlobalServices.Scenes;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;

    public class DiInitializer
    {
        [InitializerMethod(-1000)]
        public void Initialize()
        {
            var creator = new CreatorService();
            var container = GameSingletons.DependencyInjector.DependencyContainer;

            container.AddSingle(new Lazy<CreatorService>(creator));
            container.AddSingle(new Lazy<DestroyerService>(new DestroyerService()));
            container.AddSingle(new Lazy<ApplicationEventsService>(creator.Create<ApplicationEventsService>()));
            container.AddSingle(new Lazy<PauseService>(new PauseService()));
            container.AddSingle(new Lazy<NextMomentExecutorService>(new NextMomentExecutorService()));
            container.AddSingle(new Lazy<RepositoryService>(new RepositoryService()));
            container.AddSingle(new Lazy<TimeService>(new TimeService()));
            container.AddSingle(new Lazy<GameService>(creator.Create<GameService>()));
            container.AddSingle(new Lazy<TimeManagerService>(creator.Create<TimeManagerService>()));

            container.AddSingle(new Lazy<SceneService>(new SceneService()));
            container.AddSingle(new Lazy<IInputService>(InputMaker.MakeInputService(creator)));
            container.AddSingle(new Lazy<CoroutinesService>(creator.Create<CoroutinesService>()));
            container.AddSingle(new Lazy<FpsCounterService>(creator.Create<FpsCounterService>()));
            container.AddSingle(new Lazy<FpsSetterService>(new FpsSetterService()));
        }
    }
}