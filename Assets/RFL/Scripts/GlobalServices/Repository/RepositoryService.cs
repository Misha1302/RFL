namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.ApplicationEvents;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public class RepositoryService : IService
    {
        private const string Key = "GameDataKey";
        private bool _isSaving;

        private readonly Lazy<GameData> _gameData;

        public RepositoryService()
        {
            _gameData = new Lazy<GameData>(LoadGameData);
        }

        public GameData GameData => _gameData.Value;

        private GameData LoadGameData()
        {
            var gameData = LoadRawGameData();
            SubscribeOnDataSave(gameData);
            return gameData;
        }

        private static GameData LoadRawGameData()
        {
            GameData gameData;
            if (SaveSystem.Get(Key, out var value))
            {
                gameData = JsonUtility.FromJson<GameData>(value);
                GameDataFabric.SubscribeOnChanged(gameData);
            }
            else
            {
                gameData = GameDataFabric.MakeExampleGameData();
            }

            return gameData;
        }

        private void SubscribeOnDataSave(GameData gameData)
        {
            if (Application.isPlaying)
            {
                Di.Get<ApplicationEventsService>().OnAppUnFocused.Add(SaveGameData);
                Di.Get<ApplicationEventsService>().OnAppQuitting.Add(SaveGameData);
            }
            else
            {
                gameData.OnChanged += _ => SaveGameData();
            }
        }

        private void SaveGameData()
        {
            if (_isSaving) return;

            _isSaving = true;
            SaveMonoBehs();
            SaveSystem.Set(Key, JsonUtility.ToJson(GameData, true));
            _isSaving = false;
        }

        private static void SaveMonoBehs()
        {
            if (!Application.isPlaying)
                return;

            var objects = Object.FindObjectsByType<MonoBeh>(FindObjectsInactive.Include, FindObjectsSortMode.None);
            objects.ForAll(x => (x as ISavable)?.Save());
        }
    }
}