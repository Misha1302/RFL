namespace RFL.Scripts.GlobalServices.Scenes
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;

    public static class SceneInitializer
    {
        [InitializerMethod(-100)]
        public static void Initialize()
        {
            Dc.Get<SceneService>().Init();
        }
    }
}