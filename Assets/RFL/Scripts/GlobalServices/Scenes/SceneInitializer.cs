namespace RFL.Scripts.GlobalServices.Scenes
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;

    public static class SceneInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            Di.Get<SceneService>().Init();
        }
    }
}