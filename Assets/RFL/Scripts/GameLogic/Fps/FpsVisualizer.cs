namespace RFL.Scripts.GameLogic.Fps
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Tags;
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using TMPro;
    using Unity.VisualScripting;
    using UnityEngine;

    public class FpsVisualizer : MonoBeh
    {
        private TMP_Text _text;

        protected override void OnStart()
        {
            _text = CreateCanvas()
                .GetComponentInChildren<FpsTextTag>()
                .GetComponent<TMP_Text>();

            Services.FpsCounterService.OnFpsChanged += ShowFps;
        }

        private static Object CreateCanvas() => Creator.Instantiate(Resources.Load("UI/FpsCanvas"));

        private void ShowFps(float value)
        {
            _text.text = value.ToStr();
        }
    }
}