namespace RFL.Scripts.GlobalServices.Fps
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class FpsCanvasInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            if (Di.Get<RepositoryService>().GameData.needToShowFps.Value)
                CreateFpsCanvas();
        }

        private static void CreateFpsCanvas()
        {
            Creator.Instantiate(Resources.Load("UI/FpsCanvas"));
        }
    }
}