﻿namespace RFL.Scripts.GlobalServices.Pause
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class PauseInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            Dc.Get<IInputService>().OnPause += Dc.Get<PauseService>().PauseOrUnPause;

            Dc.Get<PauseService>().OnPausedChanged += isPaused =>
            {
                if (isPaused)
                {
                    var settingsCanvas = Resources.Load<SettingsCanvasTag>("UI/SettingsCanvas");
                    Dc.Get<CreatorService>().Instantiate(settingsCanvas);
                }
                else
                {
                    var canvas = Object.FindAnyObjectByType<SettingsCanvasTag>(FindObjectsInactive.Include);
                    Dc.Get<DestroyerService>().Destroy(canvas.transform);
                }
            };
        }
    }
}