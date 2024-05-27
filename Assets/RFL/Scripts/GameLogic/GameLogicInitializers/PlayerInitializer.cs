namespace RFL.Scripts.GameLogic.GameLogicInitializers
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic.Player;
    using UnityEngine;

    public static class PlayerInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            Di.Instance.AddGlobalSingleton(Object.FindObjectOfType<Player>(true));
        }
    }
}