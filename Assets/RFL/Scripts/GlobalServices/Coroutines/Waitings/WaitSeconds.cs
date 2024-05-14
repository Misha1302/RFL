namespace RFL.Scripts.GlobalServices.Coroutines.Waitings
{
    public class WaitSeconds : ICoroutineWaiting
    {
        private readonly float _startTime;
        private readonly float _seconds;

        public WaitSeconds(float seconds)
        {
            _seconds = seconds;
            _startTime = Services.TimeService.Time;
        }

        public float EndTime => _startTime + _seconds;
    }
}