namespace RFL.Scripts.GlobalServices.Coroutines.Waitings
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Time;

    public class WaitSeconds : ICoroutineWaiting
    {
        private readonly float _startTime;
        private readonly float _seconds;

        public WaitSeconds(float seconds)
        {
            _seconds = seconds;
            _startTime = Dc.Get<TimeService>().ElapsedTime;
        }

        public float EndTime => _startTime + _seconds;
    }
}