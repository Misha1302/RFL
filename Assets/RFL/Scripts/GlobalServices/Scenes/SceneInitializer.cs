namespace RFL.Scripts.GlobalServices.Scenes
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GameLogic.Entities.Plants.Trees;

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