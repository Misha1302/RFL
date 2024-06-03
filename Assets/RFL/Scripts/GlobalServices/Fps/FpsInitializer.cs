﻿namespace RFL.Scripts.GlobalServices.Fps
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions.Math.Numbers;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class FpsInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            const int maxFramesCount = 10_000;

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate =
                Di.Get<RepositoryService>().GameData.targetFps.Value.ThisOrIf(x => x < 0, maxFramesCount);

            if (Di.Get<RepositoryService>().GameData.needToShowFps.Value)
                CreateFpsCanvas();
        }

        private static void CreateFpsCanvas()
        {
            Creator.Instantiate(Resources.Load("UI/FpsCanvas"));
        }
    }
}