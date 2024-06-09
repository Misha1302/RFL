namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.Time;
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        [Inject] private Lazy<TimeService> _timeService;

        protected float TimeSinceStart => _timeService.Value.ElapsedTime;
        protected double TotalTime => _timeService.Value.TotalTime;
        protected float DeltaTime => _timeService.Value.DeltaTime;
        protected float FixedDeltaTime => _timeService.Value.FixedDeltaTime;
    }
}