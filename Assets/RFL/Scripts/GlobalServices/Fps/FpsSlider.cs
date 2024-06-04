namespace RFL.Scripts.GlobalServices.Fps
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public class FpsSlider : MonoBeh
    {
        private Slider _slider;

        protected override void OnStart()
        {
            _slider = GetComponent<Slider>();
            _slider.wholeNumbers = true;
            _slider.onValueChanged.AddListener(SetFps);

            _slider.value = Di.Get<RepositoryService>().GameData.targetFps.Value;
        }

        private void SetFps(float sliderValue)
        {
            Di.Get<RepositoryService>().GameData.targetFps.Value = (int)_slider.value;
        }
    }
}