namespace RFL.Scripts.GlobalServices.Pause
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
            Di.Get<IInputService>().OnPause += Di.Get<PauseService>().PauseOrUnPause;

            Di.Get<PauseService>().OnPausedChanged += isPaused =>
            {
                if (isPaused)
                {
                    var pauseCanvas = Resources.Load<SettingsCanvasTag>("UI/SettingsCanvas");
                    Creator.Instantiate(pauseCanvas);
                }
                else
                {
                    var canvas = Object.FindAnyObjectByType<SettingsCanvasTag>(FindObjectsInactive.Include);
                    Creator.Destroy(canvas.transform);
                }
            };
        }
    }
}