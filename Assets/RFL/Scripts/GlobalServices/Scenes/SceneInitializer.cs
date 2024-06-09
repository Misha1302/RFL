namespace RFL.Scripts.GlobalServices.Scenes
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;

    public class SceneInitializer : InjectableBase
    {
        [Inject] private Lazy<SceneService> _sceneService;

        [InitializerMethod(-100)]
        public void Initialize()
        {
            _sceneService.Value.Init();
        }
    }
}