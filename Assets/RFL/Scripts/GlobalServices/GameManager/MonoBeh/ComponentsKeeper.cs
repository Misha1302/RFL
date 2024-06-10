﻿namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.Time;
    using UnityEngine;

    public class ComponentsKeeper : MonoBehaviour
    {
        [Inject] private TimeService _timeService;

        protected float TimeSinceStart => _timeService.ElapsedTime;
        protected double TotalTime => _timeService.TotalTime;
        protected float DeltaTime => _timeService.DeltaTime;
        protected float FixedDeltaTime => _timeService.FixedDeltaTime;
    }
}