namespace RFL.Scripts.GlobalServices.Fps
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class FpsCanvasInitializer : InjectableBase
    {
        [Inject] private Lazy<RepositoryService> _repositoryService;
        [Inject] private Lazy<CreatorService> _creatorService;


        [InitializerMethod]
        public void Initialize()
        {
            if (_repositoryService.Value.GameData.needToShowFps.Value)
                CreateFpsCanvas();
        }

        private void CreateFpsCanvas()
        {
            _creatorService.Value.Instantiate(Resources.Load("UI/FpsCanvas"));
        }
    }
}