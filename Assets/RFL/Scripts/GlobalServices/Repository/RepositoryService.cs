﻿namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using UnityEngine;

    public class RepositoryService : IService
    {
        private const string Key = "GameDataKey";

        private readonly Lazy<GameData> _gameData = new(LoadGameData);
        public GameData GameData => _gameData.Value;

        private static GameData LoadGameData()
        {
            var gameData = SaveSystem.Get(Key, out var value) ? JsonUtility.FromJson<GameData>(value) : null;
            gameData ??= new GameData();
            gameData.OnChanged += SaveGameData;
            return gameData;
        }

        private static void SaveGameData(GameData data)
        {
            SaveSystem.Set(Key, JsonUtility.ToJson(data));
        }
    }
}