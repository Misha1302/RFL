namespace RFL.Scripts.UI
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GameLogic.Scenes;
    using RFL.Scripts.GlobalServices.Fps;
    using RFL.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class UiInitializer : InjectableBase
    {
        [Inject] private CreatorService _creatorService;

        [SceneInitializer(typeof(AnyScene), initializationType: InitializationType.Once)]
        public void Initialize()
        {
            _creatorService.Instantiate(Resources.Load<EventSystem>("UI/EventSystem")).gameObject
                .AddComponent<InterSceneTag>();
        }
    }
}