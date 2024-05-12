﻿namespace RFL.Scripts.GlobalServices.Time
{
    using RFL.Scripts.GameManager;

    public class TimeService : MonoBeh
    {
        public float Time { get; private set; }

        public override void Tick()
        {
            Time += UnityEngine.Time.deltaTime;
        }
    }
}