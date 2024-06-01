namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeService : MonoBeh, IService, ISavable
    {
        private long _elapsedTicks;
        private long _startTotalTicks;

        public long TotalTicks => _startTotalTicks + _elapsedTicks;
        public new double TotalTime => CalcTime(_startTotalTicks + _elapsedTicks);
        public float ElapsedTime => (float)CalcTime(_elapsedTicks);
        public new float DeltaTime => Time.deltaTime;
        public new float FixedDeltaTime => Time.fixedDeltaTime;

        public void Save()
        {
            SaveTime();
        }

        public double CalcTime(long ticks) => ticks * FixedDeltaTime;


        protected override void OnStart()
        {
            _startTotalTicks = Di.Get<RepositoryService>().GameData.totalTicks.Value;
        }

        private void SaveTime()
        {
            Di.Get<RepositoryService>().GameData.totalTicks.Value = _startTotalTicks + _elapsedTicks;
        }

        protected override void FixedTick()
        {
            if (!Di.Get<PauseService>().IsPaused)
                _elapsedTicks++;
        }
    }
}