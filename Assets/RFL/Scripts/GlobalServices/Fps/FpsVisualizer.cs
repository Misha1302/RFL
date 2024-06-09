namespace RFL.Scripts.GlobalServices.Fps
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using TMPro;

    public class FpsVisualizer : MonoBeh
    {
        [Inject] private Lazy<FpsCounterService> _fpsCounterService;
        private TMP_Text _text;

        protected override void OnStart()
        {
            _text = GetComponentInChildren<FpsTextTag>().GetComponent<TMP_Text>();

            _fpsCounterService.Value.OnFpsChanged += ShowFps;
        }

        private void ShowFps(float value)
        {
            _text.text = value.ToStr();
        }
    }
}