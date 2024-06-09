namespace RFL.Scripts.GlobalServices.Time
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeManagerService : MonoBeh, IService, ISavable
    {
        [Inject] private Lazy<TimeService> _timeService;

        public void Save()
        {
            _timeService.Value.Save();
        }

        protected override void OnStart()
        {
            _timeService.Value.OnStart();
        }

        protected override void FixedTick()
        {
            _timeService.Value.FixedTick();
        }
    }
}