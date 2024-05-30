namespace RFL.Scripts.GameLogic.Plants.Trees
{
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class TreeGrower : MonoBeh
    {
        private TreeTimeManager _treeTimeManager;

        protected override void OnStart()
        {
            _treeTimeManager = Creator.Create<TreeTimeManager>();
            _treeTimeManager.Init(TotalTime);
            _treeTimeManager.OnTimeToPhase1 += () => ChangePhase(1);
            _treeTimeManager.OnTimeToPhase2 += () => ChangePhase(2);
            _treeTimeManager.OnTimeToPhase3 += () => ChangePhase(3);
        }

        private void ChangePhase(int phase)
        {
            transform.ForAll<Transform>(Creator.Destroy);

            var resource = Resources.Load<GameObject>($"Trees/Tree ({phase} phase)");
            var instance = Creator.Instantiate(resource);
            instance.transform.SetParent(transform);
            instance.transform.localPosition =
                Vector3.zero.WithY(instance.GetComponentsInChildren<SpriteRenderer>()
                    .Max(r => r.size.y * r.transform.localScale.y) / 2);
        }
    }
}