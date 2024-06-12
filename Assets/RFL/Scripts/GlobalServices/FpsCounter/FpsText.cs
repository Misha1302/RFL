﻿namespace RFL.Scripts.GlobalServices.FpsCounter
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using TMPro;
    using UnityEngine;

    [RequireComponent(typeof(TMP_Text))]
    public class FpsText : MonoBeh
    {
        [SerializeField] private string format = "{0}";
        [Inject] private RepositoryService _repositoryService;

        private void OnValidate()
        {
            format = GetComponent<TMP_Text>().text;
        }

        protected override void OnStart()
        {
            _repositoryService.GameData.targetFps.OnChanged += SetText;
        }

        public override void SelfDestroy()
        {
            _repositoryService.GameData.targetFps.OnChanged -= SetText;
        }

        private void SetText()
        {
            var targetFps = _repositoryService.GameData.targetFps.Value;
            GetComponent<TMP_Text>().text = string.Format(format, targetFps);
        }
    }
}