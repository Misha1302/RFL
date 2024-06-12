namespace RFL.Scripts.GlobalServices.Scenes
{
    using System.Linq;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Bootstrap;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Scenes;
    using RFL.Scripts.GlobalServices.Repository.DataContainers;
    using RFL.Scripts.Helpers;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using Object = UnityEngine.Object;

    public class SceneService : InjectableBase, IService
    {
        [Inject] private DestroyerService _destroyerService;

        private Transform[] Objects => Object.FindObjectsOfType<Transform>(true);
        public SceneName CurrentScene { get; private set; }

        public void Init()
        {
            DestroyAll(false);
            ChangeScene(new CoreScene());
        }

        private void DestroyAll(bool saveData)
        {
            Objects.Select(x => x.root).Distinct().ForAll(x =>
            {
                if (!x.HasComponent<IInterScene>() && !x.IsDestroying())
                    _destroyerService.Destroy(x, saveData);
            });
        }

        public void ChangeScene(SceneName name)
        {
            CurrentScene = name;
            DestroyAll(true);
            SceneManager.LoadScene(CurrentScene, LoadSceneMode.Additive);
            InitializersManager.InitEveryIntializer(CurrentScene);
        }
    }
}