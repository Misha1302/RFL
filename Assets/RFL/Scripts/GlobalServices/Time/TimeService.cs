namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    // ReSharper disable MemberCanBeMadeStatic.Global
    public class TimeService : MonoBeh
    {
        public float TotalTime { get; private set; }
        public new float DeltaTime => UnityEngine.Time.deltaTime;
        public new float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;

        protected override void Tick()
        {
            TotalTime += UnityEngine.Time.deltaTime;
        }
    }
}