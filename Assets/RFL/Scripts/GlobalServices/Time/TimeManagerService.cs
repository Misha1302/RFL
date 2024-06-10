namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeManagerService : MonoBeh, IService, ISavable
    {
        [Inject] private TimeService _timeService;

        public void Save()
        {
            _timeService.Save();
        }

        protected override void OnStart()
        {
            _timeService.OnStart();
        }

        protected override void FixedTick()
        {
            _timeService.FixedTick();
        }
    }
}