namespace RFL.Scripts.UI
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.Fps;
    using RFL.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.EventSystems;

    public static class UiInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            Creator.Instantiate(Resources.Load<EventSystem>("UI/EventSystem")).gameObject.AddComponent<InterSceneTag>();
        }
    }
}