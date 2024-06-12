namespace RFL.Scripts.GlobalServices.Scenes
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GameLogic.Scenes;

    public class SceneInitializer : InjectableBase
    {
        [Inject] private SceneService _sceneService;

        [SceneInitializer(typeof(AnyScene), -100, InitializationType.Once)]
        public void Initialize()
        {
            _sceneService.Init();
        }
    }
}