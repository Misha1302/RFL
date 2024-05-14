﻿namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class TimeService : MonoBeh
    {
        public float Time { get; private set; }

        public override void Tick()
        {
            Time += UnityEngine.Time.deltaTime;
        }
    }
}