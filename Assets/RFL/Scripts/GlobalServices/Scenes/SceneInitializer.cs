namespace RFL.Scripts.GlobalServices.Scenes
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;

    public class SceneInitializer : InjectableBase
    {
        [Inject] private SceneService _sceneService;

        [InitializerMethod(-100)]
        public void Initialize()
        {
            _sceneService.Init();
        }
    }
}