namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using UnityEngine;

    [Serializable]
    public class GameData
    {
        public EventField<int> targetFps;
        public EventField<float> inputSpeed;
        public EventField<bool> needToShowFps;
        public EventField<EventList<string>> scenesList;
        public EventField<long> totalTicks;
        public EventField<Vector3> playerPos;

        [NonSerialized] public Action<GameData> OnChanged;

        public GameData()
        {
            inputSpeed = new EventField<float>();
            inputSpeed.OnChanged += () => OnChanged?.Invoke(this);

            needToShowFps = new EventField<bool>();
            needToShowFps.OnChanged += () => OnChanged?.Invoke(this);

            scenesList = new EventField<EventList<string>>();
            scenesList.OnChanged += () => OnChanged?.Invoke(this);

            totalTicks = new EventField<long>();
            totalTicks.OnChanged += () => OnChanged?.Invoke(this);

            targetFps = new EventField<int>();
            targetFps.OnChanged += () => OnChanged?.Invoke(this);

            playerPos = new EventField<Vector3>();
            playerPos.OnChanged += () => OnChanged?.Invoke(this);

            targetFps.Value = 60;
            inputSpeed.Value = 1f / 0.4f;
            needToShowFps.Value = true;
            scenesList.Value = new EventList<string>();
            totalTicks.Value = 0;
            playerPos.Value = Vector3.zero;

            scenesList.Value.OnChanged += _ => OnChanged?.Invoke(this);
        }
    }
}