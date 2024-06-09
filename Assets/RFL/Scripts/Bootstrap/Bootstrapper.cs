namespace RFL.Scripts.Bootstrap
{
    using RFL.Scripts.DI;

    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            DependencyInjector.CreateSingleton(Dc.Instance);
            InitializersManager.InitEveryIntializer();
        }
    }
}