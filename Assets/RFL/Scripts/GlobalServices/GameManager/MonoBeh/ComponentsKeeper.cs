namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        protected static float Time => Services.TimeService.TotalTime;
        protected static float DeltaTime => Services.TimeService.DeltaTime;
        protected static float FixedDeltaTime => Services.TimeService.FixedDeltaTime;
    }
}