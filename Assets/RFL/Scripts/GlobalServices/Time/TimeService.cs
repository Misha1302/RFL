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
        public new double TotalTime => CalcTime(TotalTicks);
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
            SetTicks();
            Dc.Get<RepositoryService>().GameData.totalTicks.OnChanged += SetTicks;
        }

        private void SetTicks()
        {
            _startTotalTicks = Dc.Get<RepositoryService>().GameData.totalTicks.Value;
        }

        private void SaveTime()
        {
            Dc.Get<RepositoryService>().GameData.totalTicks.Value = TotalTicks;
        }

        protected override void FixedTick()
        {
            if (!Dc.Get<PauseService>().IsPaused)
                _elapsedTicks++;
        }
    }
}