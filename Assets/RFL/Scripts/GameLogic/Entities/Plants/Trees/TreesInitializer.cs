namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;

    public class TreesInitializer : InjectableBase
    {
        [Inject] private RepositoryService _repositoryService;
        [Inject] private CreatorService _creatorService;

        [InitializerMethod]
        public void Initialize()
        {
            var data = _repositoryService.GameData.coreScene.Value.data;
            data.ForAll(x =>
            {
                if (x.value.Is<TreeData>())
                    _creatorService.Create<TreeGrower>().Init(x.value.Get<TreeData>());
            });
            data.Clear();
        }
    }
}