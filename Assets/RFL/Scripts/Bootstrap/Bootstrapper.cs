namespace RFL.Scripts.Bootstrap
{
    using RFL.Scripts.Bootstrap.Initialization;
    using RFL.Scripts.GameLogic.Scenes;

    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            InitializersManager.InitEveryInitializer(ScenesFactory.AnyScene());
        }
    }
}