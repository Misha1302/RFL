namespace RFL.Scripts.GlobalServices.Time
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    public class TimeService : InjectableBase, ISavable
    {
        private long _elapsedTicks;
        [Inject] private Lazy<PauseService> _pauseService;
        [Inject] private Lazy<RepositoryService> _repositoryService;
        private long _startTotalTicks;

        public long TotalTicks => _startTotalTicks + _elapsedTicks;
        public double TotalTime => CalcTime(TotalTicks);
        public float ElapsedTime => (float)CalcTime(_elapsedTicks);
        public float DeltaTime => Time.deltaTime;
        public float FixedDeltaTime => Time.fixedDeltaTime;

        public void Save()
        {
            SaveTime();
        }

        public double CalcTime(long ticks) => ticks * FixedDeltaTime;


        public void OnStart()
        {
            SetTicks();
            _repositoryService.Value.GameData.totalTicks.OnChanged += SetTicks;
        }

        private void SetTicks()
        {
            _startTotalTicks = _repositoryService.Value.GameData.totalTicks.Value;
        }

        private void SaveTime()
        {
            _repositoryService.Value.GameData.totalTicks.Value = TotalTicks;
        }

        public void FixedTick()
        {
            if (!_pauseService.Value.IsPaused)
                _elapsedTicks++;
        }
    }
}