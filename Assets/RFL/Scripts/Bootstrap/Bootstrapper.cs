namespace RFL.Scripts.Bootstrap
{
    using RFL.Scripts.GameLogic.Scenes;

    public static class Bootstrapper
    {
        public static void Bootstrap()
        {
            InitializersManager.InitEveryIntializer(new AnyScene());
        }
    }
}