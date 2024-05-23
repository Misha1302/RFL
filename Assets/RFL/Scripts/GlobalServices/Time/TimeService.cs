namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class TimeService : MonoBeh
    {
        public float TotalTime { get; private set; }
        public static float DeltaTime => UnityEngine.Time.deltaTime;
        public static float FixedDeltaTime => UnityEngine.Time.fixedDeltaTime;

        protected override void Tick()
        {
            TotalTime += UnityEngine.Time.deltaTime;
        }
    }
}