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
            var data = Di.Get<RepositoryService>().GameData.coreScene.Value.data;
            data.ForAll(x =>
            {
                if (x.value.Is<TreeData>())
                    Creator.Create<TreeGrower>().Init(x.value.Get<TreeData>());
            });
            data.Clear();
        }
    }
}