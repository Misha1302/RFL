namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.DependenciesManagement.Container;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.Extensions.Math.Vectors;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.GlobalServices.Repository.DataContainers.Primitives;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class TreeGrower : MonoBeh, ISavable, IEntity
    {
        [Inject] private CreatorService _creatorService;
        [Inject] private DestroyerService _destroyerService;
        [Inject] private RepositoryService _repositoryService;
        [Inject] private TimeService _timeService;

        private TreeData _treeData;
        private TreeTimeManager _treeTimeManager;

        private long TicksCountWhenTreeWasGrown => _treeData?.ticksCountWhenTreeWasGrown ?? 0;

        public SerializableGuid Id { get; private set; }

        public void Save()
        {
            _repositoryService.GameData.coreScene.Value.data[Id] =
                new Any(new TreeData(TicksCountWhenTreeWasGrown, transform.position, Id));
        }

        public void Init(TreeData treeData)
        {
            _treeData = treeData;
            _treeTimeManager = _creatorService.Create<TreeTimeManager>();
            _treeTimeManager.Init(_timeService.CalcTime(treeData.ticksCountWhenTreeWasGrown));
            _treeTimeManager.OnTimeToPhase += ChangePhase;

            transform.position = treeData.position;

            Id = treeData.id;
        }

        private void ChangePhase(TreePhaseType treePhaseType)
        {
            transform.ForAll<Transform>(x => _destroyerService.Destroy(x));

            var resource = Resources.Load<GameObject>($"Trees/Tree ({(int)treePhaseType} phase)");
            var instance = _creatorService.Instantiate(resource);
            instance.transform.SetParent(transform);
            instance.transform.localPosition = Vector3.zero.WithY(instance.CalcHalfOfVisibleYSize());
        }
    }
}