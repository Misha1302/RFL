namespace RFL.Scripts.GameLogic.Entities.Plants.Trees.TreeComponent
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.Extensions.Math.Vectors;
    using RFL.Scripts.GlobalServices.Creator;
    using RFL.Scripts.GlobalServices.Destroyer;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Time;
    using UnityEngine;

    public class TreeGrower : MonoBeh
    {
        [Inject] private CreatorService _creatorService;
        [Inject] private DestroyerService _destroyerService;
        [Inject] private TimeService _timeService;

        private TreeTimeManager _treeTimeManager;


        public void Init(TreeEntity treeEntity)
        {
            _treeTimeManager = _creatorService.Create<TreeTimeManager>();
            _treeTimeManager.Init(_timeService.CalcTime(treeEntity.TreeData.ticksCountWhenTreeWasGrown));
            _treeTimeManager.OnTimeToPhase += ChangePhase;
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