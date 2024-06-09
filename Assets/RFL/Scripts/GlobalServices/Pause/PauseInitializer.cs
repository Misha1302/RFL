namespace RFL.Scripts.GlobalServices.Pause
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GameLogic.Entities.Plants.Trees;
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class PauseInitializer : InjectableBase
    {
        [Inject] private PauseService _pauseService;
        [Inject] private IInputService _inputService;
        [Inject] private CreatorService _creatorService;
        [Inject] private DestroyerService _destroyerService;

        [InitializerMethod]
        public void Initialize()
        {
            _inputService.OnPause += _pauseService.PauseOrUnPause;

            _pauseService.OnPausedChanged += isPaused =>
            {
                if (isPaused)
                {
                    var settingsCanvas = Resources.Load<SettingsCanvasTag>("UI/SettingsCanvas");
                    _creatorService.Instantiate(settingsCanvas);
                }
                else
                {
                    var canvas = Object.FindAnyObjectByType<SettingsCanvasTag>(FindObjectsInactive.Include);
                    _destroyerService.Destroy(canvas.transform);
                }
            };
        }
    }
}