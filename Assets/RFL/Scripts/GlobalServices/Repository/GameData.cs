namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using UnityEngine;

    [Serializable]
    public class GameData
    {
        [SerializeField] private int targetFps;
        [SerializeField] private float inputSpeed;
        [SerializeField] private bool needToShowFps;
        [SerializeField] private EventList<string> scenesList;

        [NonSerialized] public Action<GameData> OnChanged;

        public GameData()
        {
            targetFps = 60;
            inputSpeed = 1f / 0.4f;
            needToShowFps = true;
            scenesList = new EventList<string>();

            scenesList.OnChanged += _ => OnChanged?.Invoke(this);
        }

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

        public bool NeedToShowFps
        {
            get => needToShowFps;
            set
            {
                needToShowFps = value;
                OnChanged(this);
            }
        }

        public EventList<string> ScenesList
        {
            get => scenesList;
            set
            {
                scenesList = value;
                scenesList.OnChanged += _ => OnChanged(this);
                OnChanged(this);
            }
        }
    }
}