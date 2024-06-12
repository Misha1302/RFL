namespace RFL.Scripts.GlobalServices.FpsCounter.Visualizer
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GameLogic.Scenes;
    using RFL.Scripts.GlobalServices.Creator;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    public class FpsCanvasInitializer : InjectableBase
    {
        [Inject] private RepositoryService _repositoryService;
        [Inject] private CreatorService _creatorService;


        [SceneInitializer(typeof(CoreScene))]
        public void Initialize()
        {
            if (_repositoryService.GameData.needToShowFps.Value)
                CreateFpsCanvas();
        }

        private void CreateFpsCanvas()
        {
            _creatorService.Instantiate(Resources.Load("UI/FpsCanvas"));
        }
    }
}