namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.Helpers;

    public class TreesInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            var data = Dc.Get<RepositoryService>().GameData.coreScene.Value.data;
            data.ForAll(x =>
            {
                if (x.value.Is<TreeData>())
                    Dc.Get<CreatorService>().Create<TreeGrower>().Init(x.value.Get<TreeData>());
            });
            data.Clear();
        }
    }
}