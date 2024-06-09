namespace RFL.Scripts.Singletons
{
    using RFL.Scripts.DependenciesManagement.Container;
    using RFL.Scripts.DependenciesManagement.Injector;

    public static class GameSingletons
    {
        public static readonly DependencyInjector DependencyInjector;

        static GameSingletons()
        {
            DependencyInjector = new DependencyInjector(new DependencyContainer());
        }
    }
}