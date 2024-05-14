namespace RFL.Scripts
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic.Player;
    using RFL.Scripts.GlobalServices.Coroutines;
    using RFL.Scripts.GlobalServices.GameManager;
    using RFL.Scripts.GlobalServices.InputManager;
    using RFL.Scripts.GlobalServices.PauseService;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class Bootstrap : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadRuntimeMethod()
        {
            Di.Instance.AddGlobalSingleton(new PauseService());
            Di.Instance.AddGlobalSingleton(Creator.Create<GameService>());

            Di.Instance.AddGlobalSingleton(FindObjectOfType<Player>());
            Di.Instance.AddGlobalSingleton<IInputService>(Creator.Create<PcInputService>());
            Di.Instance.AddGlobalSingleton(Creator.Create<TimeService>());
            Di.Instance.AddGlobalSingleton(Creator.Create<CoroutinesService>());
        }
    }
}