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
            if (!saveChanged) return;
            saveChanged = false;

            InitBuildSettings();
            InitRepository();
        }

        private void InitRepository()
        {
            var repositoryService = new RepositoryService();
            repositoryService.GameData.ScenesList.Clear();
            repositoryService.GameData.ScenesList.AddRange(scenes.Select(x => x.name));
        }

        private void InitBuildSettings()
        {
            EditorBuildSettings.scenes = scenes
                .Select(x => new EditorBuildSettingsScene(AssetDatabase.GetAssetPath(x), true))
                .ToArray();
        }
    }
}