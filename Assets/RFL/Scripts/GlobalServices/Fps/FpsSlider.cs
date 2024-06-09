namespace RFL.Scripts.GlobalServices.Fps
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Slider))]
    public class FpsSlider : MonoBeh
    {
        [Inject] private Lazy<RepositoryService> _repositoryService;

        private Slider _slider;

        protected override void OnStart()
        {
            _slider = GetComponent<Slider>();
            _slider.wholeNumbers = true;
            _slider.onValueChanged.AddListener(SetFps);

            _slider.value = _repositoryService.Value.GameData.targetFps.Value
                .ThisOrIf(x => x < 0, (int)_slider.maxValue);
        }

        private void SetFps(float sliderValue)
        {
            _repositoryService.Value.GameData.targetFps.Value =
                (int)sliderValue != (int)_slider.maxValue ? (int)sliderValue : -1;
        }
    }
}