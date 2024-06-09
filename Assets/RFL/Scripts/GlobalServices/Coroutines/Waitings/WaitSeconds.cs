namespace RFL.Scripts.GlobalServices.Coroutines.Waitings
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GlobalServices.Time;

    public class WaitSeconds : InjectableBase, ICoroutineWaiting
    {
        [Inject] private Lazy<TimeService> _timeService;

        private readonly float _startTime;
        private readonly float _seconds;

        public WaitSeconds(float seconds)
        {
            _seconds = seconds;
            // ReSharper disable once ExpressionIsAlwaysNull
            _startTime = _timeService!.Value.ElapsedTime;
        }

        public float EndTime => _startTime + _seconds;
    }
}