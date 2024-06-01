﻿#if UNITY_EDITOR

namespace RFL.Scripts.EditorHelpers
{
    using System.Linq;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEditor;
    using UnityEngine;

    public class ScenesSetter : MonoBehaviour
    {
        [SerializeField] private SceneAsset[] scenes;
        [SerializeField] private bool saveChanged;

        private void OnValidate()
        {
            if (Application.isPlaying) return;
            
            if (!saveChanged) return;
            saveChanged = false;

            InitBuildSettings();
            InitRepository();
        }

        private void InitRepository()
        {
            var repositoryService = new RepositoryService();
            repositoryService.GameData.scenesList.Value.Clear();
            repositoryService.GameData.scenesList.Value.AddRange(scenes.Select(x => x.name));
        }

        private void InitBuildSettings()
        {
            EditorBuildSettings.scenes = scenes
                .Select(x => new EditorBuildSettingsScene(AssetDatabase.GetAssetPath(x), true))
                .ToArray();
        }
    }
}

#endif