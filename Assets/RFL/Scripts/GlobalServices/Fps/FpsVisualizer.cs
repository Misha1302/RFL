namespace RFL.Scripts.GlobalServices.Fps
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Tags;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using TMPro;

    public class FpsVisualizer : MonoBeh
    {
        private TMP_Text _text;

        protected override void OnStart()
        {
            _text = GetComponentInChildren<FpsTextTag>().GetComponent<TMP_Text>();

            Di.Get<FpsCounterService>().OnFpsChanged += ShowFps;
        }

        private void ShowFps(float value)
        {
            _text.text = value.ToStr();
        }
    }
}