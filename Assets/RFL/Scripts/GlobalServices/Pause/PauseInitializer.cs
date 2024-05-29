namespace RFL.Scripts.GlobalServices.Pause
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Input.Services;

    public static class PauseInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            Di.Get<IInputService>().OnPause += Di.Get<PauseService>().PauseOrUnPause;
        }
    }
}