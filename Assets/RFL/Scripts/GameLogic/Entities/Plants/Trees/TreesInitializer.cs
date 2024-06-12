namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using System.Linq;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Scenes;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;

    public class TreesInitializer : InjectableBase
    {
        [Inject] private RepositoryService _repositoryService;
        [Inject] private CreatorService _creatorService;

        [SceneInitializer(typeof(CoreScene))]
        public void Initialize()
        {
            var data = _repositoryService.GameData.sceneDatas.First(x => x.name == CoreScene.Name).data;
            data.ForAll(x =>
            {
                if (x.value.Is<TreeData>())
                    _creatorService.Create<TreeGrower>().Init(x.value.Get<TreeData>());
            });
            data.Clear();
        }
    }
}