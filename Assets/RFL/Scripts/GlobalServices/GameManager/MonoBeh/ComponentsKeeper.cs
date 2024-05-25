namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Time;
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        protected static float Time => Di.Get<TimeService>().TotalFixedTime;
        protected static float DeltaTime => Di.Get<TimeService>().DeltaTime;
        protected static float FixedDeltaTime => Di.Get<TimeService>().FixedDeltaTime;
    }
}