namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.ApplicationEvents;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeService : MonoBeh, IService
    {
        private long _elapsedTicks;
        private long _startTotalTicks;

        public new double TotalTime => (_startTotalTicks + _elapsedTicks) * FixedDeltaTime;
        public float ElapsedTime => _elapsedTicks * FixedDeltaTime;
        public new float DeltaTime => Time.deltaTime;
        public new float FixedDeltaTime => Time.fixedDeltaTime;


        protected override void OnStart()
        {
            _startTotalTicks = Di.Get<RepositoryService>().GameData.totalTicks.Value;
            Di.Get<ApplicationEventsService>().SubscribeOnAppQuit(SaveTime);
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