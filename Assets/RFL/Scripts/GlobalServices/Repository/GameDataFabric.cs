namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic.Entities.Plants.Trees;
    using RFL.Scripts.GlobalServices.Repository.DataContainers.Primitives;
    using UnityEngine;

    public static class GameDataFabric
    {
        public const int DefaultTargetFps = -1;
        public const float DefaultInputSpeed = 1f / 0.4f;
        public const bool DefaultNeedToShowFps = true;
        public const long DefaultTotalTicks = 0;
        public static readonly Vector3 DefaultPlayerPos = Vector3.zero;

        public static GameData MakeExampleGameData()
        {
            var gd = MakeStandardGameData();
            gd.coreScene.Value.data = ExampleTrees();
            return gd;
        }

        public static void SubscribeOnChanged(GameData gd)
        {
            gd.targetFps.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.inputSpeed.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.needToShowFps.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.scenesList.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.totalTicks.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.playerPos.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.coreScene.OnChanged += () => gd.OnChanged?.Invoke(gd);

            gd.coreScene.Value.data.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.scenesList.Value.OnChanged += _ => gd.OnChanged?.Invoke(gd);
        }

        private static EventSerializableDictionary<SerializableGuid, Any> ExampleTrees()
        {
            var d = new EventSerializableDictionary<SerializableGuid, Any>();
            var guid = Guid.NewGuid();
            d[guid] = new Any(new TreeData(0, Vector3.one, guid));
            return d;
        }

        public static GameData MakeStandardGameData()
        {
            var gd = new GameData
            {
                targetFps = { Value = -1 },
                inputSpeed = { Value = 1f / 0.4f },
                needToShowFps = { Value = true }
            };

            SubscribeOnChanged(gd);

            return gd;
        }
    }
}