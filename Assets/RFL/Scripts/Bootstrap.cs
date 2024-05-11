namespace RFL.Scripts
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic;
    using RFL.Scripts.GlobalServices.Coroutines;
    using RFL.Scripts.GlobalServices.InputManager;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class Bootstrap : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadRuntimeMethod()
        {
            Di.Instance.AddGlobalSingleton(Creator.Create<GameManager.GameManager>());

            Di.Instance.AddGlobalSingleton(FindObjectOfType<Player>());
            Di.Instance.AddGlobalSingleton<IInputManager>(Creator.Create<PcInputManager>());
            Di.Instance.AddGlobalSingleton(Creator.Create<GlobalTime>());
            Di.Instance.AddGlobalSingleton(Creator.Create<CoroutinesManager>());
        }
    }
}