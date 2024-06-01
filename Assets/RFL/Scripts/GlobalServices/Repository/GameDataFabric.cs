namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using RFL.Scripts.GameLogic.Plants.Trees;
    using UnityEngine;

    public static class GameDataFabric
    {
        public static GameData MakeExampleGameData()
        {
            var gd = new GameData();
            gd.targetFps.Value = 60;
            gd.inputSpeed.Value = 1f / 0.4f;
            gd.needToShowFps.Value = true;
            gd.playerPos.Value = new Vector2(9.75f, 0.93f);
            gd.coreScene.Value.treesData = ExampleTrees();

            gd.inputSpeed.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.needToShowFps.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.scenesList.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.totalTicks.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.targetFps.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.playerPos.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.coreScene.OnChanged += () => gd.OnChanged?.Invoke(gd);

            gd.coreScene.Value.treesData.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.scenesList.Value.OnChanged += _ => gd.OnChanged?.Invoke(gd);

            return gd;
        }

        private static SerializableDictionary<SerializableGuid, TreeData> ExampleTrees()
        {
            var d = new SerializableDictionary<SerializableGuid, TreeData>();
            var guid = Guid.NewGuid();
            d[guid] = new TreeData(0, Vector3.one, guid);
            return d;
        }

        public static GameData MakeStandardGameData()
        {
            var gd = new GameData
            {
                targetFps = { Value = 60 },
                inputSpeed = { Value = 1f / 0.4f },
                needToShowFps = { Value = true }
            };

            gd.inputSpeed.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.needToShowFps.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.scenesList.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.totalTicks.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.targetFps.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.playerPos.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.coreScene.OnChanged += () => gd.OnChanged?.Invoke(gd);

            gd.coreScene.Value.treesData.OnChanged += () => gd.OnChanged?.Invoke(gd);
            gd.scenesList.Value.OnChanged += _ => gd.OnChanged?.Invoke(gd);

            return gd;
        }
    }
}