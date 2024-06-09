namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Injector;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;

    public class TreesInitializer : InjectableBase
    {
        [Inject] private Lazy<RepositoryService> _repositoryService;
        [Inject] private Lazy<CreatorService> _creatorService;

        [InitializerMethod]
        public void Initialize()
        {
            var data = _repositoryService.Value.GameData.coreScene.Value.data;
            data.ForAll(x =>
            {
                if (x.value.Is<TreeData>())
                    _creatorService.Value.Create<TreeGrower>().Init(x.value.Get<TreeData>());
            });
            data.Clear();
        }
    }
}