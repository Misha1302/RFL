namespace RFL.Scripts.GlobalServices.Pause
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public class PauseInitializer : InjectableBase
    {
        [Inject] private Lazy<PauseService> _pauseService;
        [Inject] private Lazy<IInputService> _inputService;
        [Inject] private Lazy<CreatorService> _creatorService;
        [Inject] private Lazy<DestroyerService> _destroyerService;

        [InitializerMethod]
        public void Initialize()
        {
            _inputService.Value.OnPause += _pauseService.Value.PauseOrUnPause;

            _pauseService.Value.OnPausedChanged += isPaused =>
            {
                if (isPaused)
                {
                    var settingsCanvas = Resources.Load<SettingsCanvasTag>("UI/SettingsCanvas");
                    _creatorService.Value.Instantiate(settingsCanvas);
                }
                else
                {
                    var canvas = Object.FindAnyObjectByType<SettingsCanvasTag>(FindObjectsInactive.Include);
                    _destroyerService.Value.Destroy(canvas.transform);
                }
            };
        }
    }
}