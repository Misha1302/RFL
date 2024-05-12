namespace RFL.Scripts.GameManager
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.InputManager;
    using RFL.Scripts.GlobalServices.Time;

    public static class Services
    {
        public static IInputService InputService => Di.Instance.GetGlobalSingleton<IInputService>();
        public static TimeService TimeService => Di.Instance.GetGlobalSingleton<TimeService>();
        public static GameService GameService => Di.Instance.GetGlobalSingleton<GameService>();
        public static PauseService PauseService => Di.Instance.GetGlobalSingleton<PauseService>();
    }
}