namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using UnityEngine;

    [Serializable]
    public class GameData
    {
        [SerializeField] private int targetFps = 60;
        [SerializeField] private float inputSpeed = 1f / 0.4f;

        [NonSerialized] public Action<GameData> OnChanged;

        public int TargetFps
        {
            get => targetFps;
            set
            {
                targetFps = value;
                OnChanged(this);
            }
        }

        public float InputSpeed
        {
            get => inputSpeed;
            set
            {
                inputSpeed = value;
                OnChanged(this);
            }
        }
    }
}