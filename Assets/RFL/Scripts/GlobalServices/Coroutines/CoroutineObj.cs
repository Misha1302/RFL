namespace RFL.Scripts.GlobalServices.Coroutines
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Coroutines.Waitings;
    using RFL.Scripts.GlobalServices.Time;

    public class CoroutineObj
    {
        private readonly IEnumerator<ICoroutineWaiting> _enumerator;
        [CanBeNull] private readonly Action _whenCoroutineEnd;

        private bool _finished;

        public Action OnEnd;

        public CoroutineObj(IEnumerator<ICoroutineWaiting> enumerator, [CanBeNull] Action whenCoroutineEnd)
        {
            _enumerator = enumerator;
            _whenCoroutineEnd = whenCoroutineEnd;

            OnEnd += OnEndHandler;
        }

        private bool Finished
        {
            set
            {
                _finished = value;
                if (_finished) OnEnd?.Invoke();
            }
        }


        private void OnEndHandler()
        {
            _whenCoroutineEnd?.Invoke();
            _enumerator.Dispose();
        }

        public void Tick()
        {
            if (_enumerator.Current is WaitNextFrame) Next();

            if (_enumerator.Current is WaitSeconds s)
                if (Di.Instance.GetGlobalSingleton<GlobalTime>().Time >= s.EndTime)
                    Next();
        }

        public void FixedTick()
        {
            if (_enumerator.Current is WaitNextFixed) Next();
        }

        private void Next()
        {
            Finished = _enumerator.MoveNext();
        }

        public void Stop()
        {
            Finished = true;
        }
    }
}