namespace RFL.Scripts.EditorHelpers
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GameLogic.Entities.Plants.Trees;
    using RFL.Scripts.GameLogic.Entities.Plants.Trees.TreeComponent;
    using RFL.Scripts.GlobalServices.Creator;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Time;
    using UnityEditor;
    using UnityEngine;

    public class EditorTreeCreator : MonoBeh
    {
        [SerializeField] private bool createTree;
        [Inject] private CreatorService _creatorService;
        [Inject] private TimeService _timeService;

        private void OnValidate()
        {
            if (!Application.isPlaying)
                return;
            if (!createTree)
                return;

            EditorApplication.delayCall += () =>
            {
                _creatorService.Create<TreeEntity>()
                    .Init(new TreeData(_timeService.TotalTicks, Vector3.zero, Guid.NewGuid()));
            };
        }
    }
}