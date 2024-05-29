namespace RFL.Scripts.GlobalServices.Scenes
{
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.Helpers;
    using UnityEditor;
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class SceneService : IService
    {
        private static Transform[] Objects => Object.FindObjectsOfType<Transform>(true);

        public void Init()
        {
            var startScene = SceneManager.GetActiveScene().name;
            UnpackAll();
            DestroyAll();
            LoadSceneAdditive(startScene);
        }

        private void DestroyAll()
        {
            Objects.ForAll(x =>
            {
                if (!x.HasComponent<IInterScene>())
                    Creator.Destroy(x);
            });
        }

        public void LoadSceneAdditive(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
            UnpackAll();
        }

        private static void UnpackAll()
        {
            var prefabs = AssetDatabase.FindAssets("t:prefab", new[] { "Assets/" });
            prefabs = prefabs.Select(AssetDatabase.GUIDToAssetPath).ToArray();
            prefabs.ForAll(path =>
            {
                var prefabAssetRoot = AssetDatabase.LoadMainAssetAtPath(path) as GameObject;
                if (prefabAssetRoot == null) return;

                PrefabUtility.UnpackAllInstancesOfPrefab(prefabAssetRoot, PrefabUnpackMode.Completely,
                    InteractionMode.AutomatedAction);
            });
        }
    }
}