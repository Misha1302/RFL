namespace RFL.Scripts.GlobalServices.Fps
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    public class FpsSetterService : InjectableBase, IService
    {
        [Inject] private Lazy<RepositoryService> _repositoryService;

        public FpsSetterService()
        {
            SetTargetFps();
            _repositoryService.Value.GameData.targetFps.OnChanged += SetTargetFps;
        }

        private void SetTargetFps()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = _repositoryService.Value.GameData.targetFps.Value;
        }
    }
}