namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeService : MonoBeh, IService
    {
        private double _totalFixedTime;

        public float TotalFixedTime => (float)_totalFixedTime;
        public new float DeltaTime => UnityEngine.Time.deltaTime;
        public new float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;


        protected override void FixedTick()
        {
            _totalFixedTime += FixedDeltaTime;
        }
    }
}