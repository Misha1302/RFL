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

    public class DiInitializer
    {
        [InitializerMethod(-1000)]
        public void Initialize()
        {
            var creator = new CreatorService();
            Dc.Instance.AddSingle(creator);
            Dc.Instance.AddSingle(new DestroyerService());
            Dc.Instance.AddSingle(creator.Create<ApplicationEventsService>());
            Dc.Instance.AddSingle(new PauseService());
            Dc.Instance.AddSingle(new NextMomentExecutorService());
            Dc.Instance.AddSingle(new RepositoryService());
            Dc.Instance.AddSingle(new TimeService());
            Dc.Instance.AddSingle(creator.Create<GameService>());
            Dc.Instance.AddSingle(creator.Create<TimeManagerService>());

            Dc.Instance.AddSingle(new SceneService());
            Dc.Instance.AddSingle(InputMaker.MakeInputService(creator));
            Dc.Instance.AddSingle(creator.Create<CoroutinesService>());
            Dc.Instance.AddSingle(creator.Create<FpsCounterService>());
            Dc.Instance.AddSingle(new FpsSetterService());
        }
    }
}