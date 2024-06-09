namespace RFL.Scripts.UI
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GlobalServices.Fps;
    using RFL.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public class UiInitializer : InjectableBase
    {
        [Inject] private Lazy<CreatorService> _creatorService;

        [InitializerMethod]
        public void Initialize()
        {
            _creatorService.Value.Instantiate(Resources.Load<EventSystem>("UI/EventSystem")).gameObject
                .AddComponent<InterSceneTag>();
        }
    }
}