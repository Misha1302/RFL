namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Time;
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        protected static float TimeSinceStart => Di.Get<TimeService>().ElapsedTime;
        protected static double TotalTime => Di.Get<TimeService>().TotalTime;
        protected static float DeltaTime => Di.Get<TimeService>().DeltaTime;
        protected static float FixedDeltaTime => Di.Get<TimeService>().FixedDeltaTime;
    }
}