namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class TimeService : MonoBeh
    {
        public float TotalTime { get; private set; }

        public override void Tick()
        {
            TotalTime += UnityEngine.Time.deltaTime;
        }
    }
}