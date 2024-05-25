namespace RFL.Scripts
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic.Fps;
    using RFL.Scripts.GameLogic.Player;
    using RFL.Scripts.GameScreen.Orientation;
    using RFL.Scripts.GlobalServices.Coroutines;
    using RFL.Scripts.GlobalServices.GameManager;
    using RFL.Scripts.GlobalServices.Input;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Repository;
    using UnityEngine;

    public class Bootstrap : MonoBehaviour
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void OnBeforeSceneLoadRuntimeMethod()
        {
            Di.Instance.AddGlobalSingleton(new PauseService());
            Di.Instance.AddGlobalSingleton(Creator.Create<GameService>());

            Di.Instance.AddGlobalSingleton(new RepositoryService());
            Di.Instance.AddGlobalSingleton(FindObjectOfType<Player>(true));
            Di.Instance.AddGlobalSingleton(InputMaker.MakeInputService());
            Di.Instance.AddGlobalSingleton(Creator.Create<ScreenOrientator>());
            Di.Instance.AddGlobalSingleton(Creator.Create<TimeService>());
            Di.Instance.AddGlobalSingleton(Creator.Create<CoroutinesService>());
            Di.Instance.AddGlobalSingleton(Creator.Create<FpsCounterService>());

            Creator.Create<FpsSetter>();
            Creator.Create<UiInitializer>();
        }
    }
}