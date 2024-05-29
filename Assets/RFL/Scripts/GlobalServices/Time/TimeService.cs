namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeService : MonoBeh, IService
    {
        private double _totalFixedTime;

        public float TotalFixedTime => (float)_totalFixedTime;
        public new float DeltaTime => UnityEngine.Time.deltaTime;
        public new float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;


        protected override void FixedTick()
        {
            if (!Di.Get<PauseService>().IsPaused)
                _totalFixedTime += FixedDeltaTime;
        }
    }
}