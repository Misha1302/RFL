namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        protected static float Time => Services.TimeService.TotalFixedTime;
        protected static float DeltaTime => Services.TimeService.DeltaTime;
        protected static float FixedDeltaTime => Services.TimeService.FixedDeltaTime;
    }
}