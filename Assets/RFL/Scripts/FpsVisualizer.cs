namespace RFL.Scripts
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using TMPro;
    using UnityEngine;

    public class FpsVisualizer : MonoBeh
    {
        [SerializeField] private TMP_Text outputText;

        protected override void OnStart()
        {
            Services.FpsCounterService.OnFpsChanged += ShowFps;
        }

        private void ShowFps(float value)
        {
            outputText.text = value.ToStr();
        }
    }
}