namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using RFL.Scripts.GlobalServices.Repository.DataContainers;
    using RFL.Scripts.GlobalServices.Repository.DataContainers.Primitives;
    using UnityEngine;

    [Serializable]
    public class GameData
    {
        public EventField<int> targetFps = new();
        public EventField<float> inputSpeed = new();
        public EventField<bool> needToShowFps = new();
        public EventField<EventList<string>> scenesList = new();
        public EventField<long> totalTicks = new();
        public EventField<Vector3> playerPos = new();
        public EventList<SceneData> sceneDatas = new();

        [NonSerialized] public Action<GameData> OnChanged;
    }
}