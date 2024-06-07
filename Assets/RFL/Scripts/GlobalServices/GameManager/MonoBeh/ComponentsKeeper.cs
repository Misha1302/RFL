namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Time;
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        protected static float TimeSinceStart => Dc.Get<TimeService>().ElapsedTime;
        protected static double TotalTime => Dc.Get<TimeService>().TotalTime;
        protected static float DeltaTime => Dc.Get<TimeService>().DeltaTime;
        protected static float FixedDeltaTime => Dc.Get<TimeService>().FixedDeltaTime;
    }
}