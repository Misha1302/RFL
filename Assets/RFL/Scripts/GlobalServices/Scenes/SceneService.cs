namespace RFL.Scripts.GlobalServices.Scenes
{
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Object = UnityEngine.Object;

    public class SceneService : IService
    {
        private Transform[] Objects => Object.FindObjectsOfType<Transform>(true);

        public void Init()
        {
            var startScene = SceneManager.GetActiveScene().name;
            DestroyAll(false);
            LoadSceneAdditive(startScene);
        }

        private void DestroyAll(bool saveData)
        {
            Objects.Select(x => x.root).Distinct().ForAll(x =>
            {
                if (!x.HasComponent<IInterScene>())
                    Creator.Destroy(x, saveData);
            });
        }

        public void LoadSceneAdditive(string name)
        {
            SceneManager.LoadScene(name, LoadSceneMode.Additive);
        }
    }
}