namespace RFL.Scripts.Repository
{
    using System;
    using System.IO;
    using UnityEngine;

    public class RepositoryService
    {
        private const string Key = "GameDataKey";

        private readonly Lazy<GameData> _gameData = new(LoadGameData);
        public GameData GameData => _gameData.Value;

        private static GameData LoadGameData()
        {
            var gameData = SaveSystem.Get(Key, out var value) ? JsonUtility.FromJson<GameData>(value) : new GameData();
            gameData.OnChanged += SaveGameData;
            return gameData;
        }

        private static void SaveGameData(GameData data)
        {
            SaveSystem.Set(Key, JsonUtility.ToJson(data));
        }
    }

    public static class SaveSystem
    {
        public static void Set(string key, string value) => File.WriteAllText(key, value);

        public static bool Get(string key, out string value)
        {
            value = !File.Exists(key) ? null : File.ReadAllText(key);
            return value != null;
        }
    }
}