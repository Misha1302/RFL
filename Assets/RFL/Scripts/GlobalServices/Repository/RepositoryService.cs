namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.ApplicationEvents;
    using UnityEngine;

    public class RepositoryService : IService
    {
        private const string Key = "GameDataKey";

        private readonly Lazy<GameData> _gameData;

        public RepositoryService()
        {
            _gameData = new Lazy<GameData>(LoadGameData);
        }

        public GameData GameData => _gameData.Value;

        private GameData LoadGameData()
        {
            var gameData = SaveSystem.Get(Key, out var value) ? JsonUtility.FromJson<GameData>(value) : null;
            gameData ??= new GameData();

            if (!Application.isEditor)
                Di.Get<ApplicationEventsService>().SubscribeOnAppQuit(SaveGameData, -100);
            else
                gameData.OnChanged += _ => SaveGameData();

            return gameData;
        }

        private void SaveGameData()
        {
            SaveSystem.Set(Key, JsonUtility.ToJson(GameData));
        }
    }
}