﻿namespace RFL.Scripts.GlobalServices.Coroutines.Waitings
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GlobalServices.Time;

    public class WaitSeconds : InjectableBase, ICoroutineWaiting
    {
        [Inject] private TimeService _timeService;

        private readonly float _startTime;
        private readonly float _seconds;

        public WaitSeconds(float seconds)
        {
            _seconds = seconds;
            // ReSharper disable once ExpressionIsAlwaysNull
            _startTime = _timeService!.ElapsedTime;
        }

        public float EndTime => _startTime + _seconds;
    }
}