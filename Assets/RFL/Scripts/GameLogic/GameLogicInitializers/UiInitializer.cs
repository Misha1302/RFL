namespace RFL.Scripts.GameLogic.GameLogicInitializers
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class UiInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            Creator.Instantiate(Resources.Load("UI/EventSystem"));
        }
    }
}