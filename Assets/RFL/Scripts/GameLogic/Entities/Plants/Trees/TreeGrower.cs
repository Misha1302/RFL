namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using RFL.Scripts.DI;
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
        private TreeData _treeData;
        private TreeTimeManager _treeTimeManager;

        public SerializableGuid Id { get; private set; }

        public void Save()
        {
            Dc.Get<RepositoryService>().GameData.coreScene.Value.data[Id] =
                new Any(new TreeData(_treeData?.ticksCountWhenTreeWasGrown ?? 0, transform.position, Id));
        }

        public void Init(TreeData treeData)
        {
            _treeData = treeData;
            _treeTimeManager = Dc.Get<CreatorService>().Create<TreeTimeManager>();
            _treeTimeManager.Init(Dc.Get<TimeService>().CalcTime(treeData.ticksCountWhenTreeWasGrown));
            _treeTimeManager.OnTimeToPhase += ChangePhase;

            transform.position = treeData.position;

            Id = treeData.id;
        }

        private void ChangePhase(TreePhaseType treePhaseType)
        {
            transform.ForAll<Transform>(x => Dc.Get<DestroyerService>().Destroy(x));

            var resource = Resources.Load<GameObject>($"Trees/Tree ({(int)treePhaseType} phase)");
            var instance = Dc.Get<CreatorService>().Instantiate(resource);
            instance.transform.SetParent(transform);
            instance.transform.localPosition = Vector3.zero.WithY(instance.CalcHalfOfVisibleYSize());
        }
    }
}