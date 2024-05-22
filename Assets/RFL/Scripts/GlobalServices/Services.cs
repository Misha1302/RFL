namespace RFL.Scripts.GlobalServices
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Coroutines;
    using RFL.Scripts.GlobalServices.GameManager;
    using RFL.Scripts.GlobalServices.Input;
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Time;

    public static class Services
    {
        public static IInputService InputService => Di.Instance.GetGlobalSingleton<IInputService>();
        public static TimeService TimeService => Di.Instance.GetGlobalSingleton<TimeService>();
        public static GameService GameService => Di.Instance.GetGlobalSingleton<GameService>();
        public static PauseService PauseService => Di.Instance.GetGlobalSingleton<PauseService>();
        public static CoroutinesService CoroutinesService => Di.Instance.GetGlobalSingleton<CoroutinesService>();
    }
}