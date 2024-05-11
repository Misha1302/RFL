namespace RFL.Scripts.GlobalServices.Coroutines.Waitings
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Time;

    public class WaitSeconds : ICoroutineWaiting
    {
        public readonly float StartTime;
        public readonly float Seconds;

        public WaitSeconds(float seconds)
        {
            Seconds = seconds;
            StartTime = Di.Instance.GetGlobalSingleton<GlobalTime>().Time;
        }

        public float EndTime => StartTime + Seconds;
    }
}