namespace RFL.Scripts.GameLogic.Entities.Plants.Trees.TreeComponent
{
    using System.Linq;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Container;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.GlobalServices.Repository.DataContainers;
    using RFL.Scripts.GlobalServices.Repository.DataContainers.Primitives;
    using RFL.Scripts.GlobalServices.Scenes;

    public class TreeSaver : MonoBeh, ISavable
    {
        [Inject] private RepositoryService _repositoryService;
        private SceneName _sceneGrownName;
        [Inject] private SceneService _sceneService;
        private TreeEntity _treeEntity;

        private long TicksCountWhenTreeWasGrown => _treeEntity.TreeData.ticksCountWhenTreeWasGrown;
        private SerializableGuid Id => _treeEntity.TreeData.id;

        public void Save()
        {
            var sceneData = _repositoryService.GameData.sceneDatas.First(x => x.name == _sceneGrownName).data;
            var treeData = new TreeData(TicksCountWhenTreeWasGrown, transform.position, Id);
            sceneData[Id] = new Any(treeData);
        }

        public void Init(TreeEntity treeEntity)
        {
            _treeEntity = treeEntity;
            _sceneGrownName = _sceneService.CurrentScene;
        }
    }
}