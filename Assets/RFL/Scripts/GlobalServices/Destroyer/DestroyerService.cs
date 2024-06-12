﻿namespace RFL.Scripts.GlobalServices.Destroyer
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using RFL.Scripts.GlobalServices.Scenes;
    using UnityEngine;

    public class DestroyerService
    {
        public void Destroy(Transform transform, bool needToSaveData = true)
        {
            MarkChildrenAsDestroyed(transform);

            var monoBehs = transform.GetComponentsInChildren<MonoBeh>(true);
            if (needToSaveData)
                SaveChildren(monoBehs);

            DestroyChildrensMonoBehs(monoBehs);

            Object.Destroy(transform.gameObject);
        }

        private static void DestroyChildrensMonoBehs(MonoBeh[] monoBehs)
        {
            monoBehs.ForAll(x => x.SelfDestroy());
        }

        private static void SaveChildren(MonoBeh[] monoBehs)
        {
            monoBehs.ForAll(x => (x as ISavable)?.Save());
        }

        private static void MarkChildrenAsDestroyed(Transform transform)
        {
            var children = transform.GetComponentsInChildren<Transform>(true);
            children.ForAll(x => x.AddComponentIfNotAdded<DestroyingTag>());
        }
    }
}