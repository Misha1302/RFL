namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.ApplicationEvents;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeService : MonoBeh, IService
    {
        private double _elapsedTime;
        private double _startTotalTime;

        public new double TotalTime => _startTotalTime + _elapsedTime;

        public float ElapsedTime => (float)_elapsedTime;
        public new float DeltaTime => Time.deltaTime;
        public new float FixedDeltaTime => Time.fixedDeltaTime;


        protected override void OnStart()
        {
            _startTotalTime = Di.Get<RepositoryService>().GameData.totalTime.Value;
            Di.Get<ApplicationEventsService>().SubscribeOnAppQuit(SaveTime);
        }

        private void SaveTime()
        {
            Di.Get<RepositoryService>().GameData.totalTime.Value = TotalTime;
        }

        protected override void FixedTick()
        {
            if (!Di.Get<PauseService>().IsPaused)
                _elapsedTime += FixedDeltaTime;
        }
    }
}