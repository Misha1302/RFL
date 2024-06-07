namespace RFL.Scripts.Helpers
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    public class DestroyerService
    {
        public void Destroy(Transform transform, bool saveData = true)
        {
            var monoBehs = transform.GetComponentsInChildren<MonoBeh>(true);
            if (saveData)
                monoBehs.ForAll(x => (x as ISavable)?.Save());
            monoBehs.ForAll(x => x.SelfDestroy());
            Object.Destroy(transform.gameObject);
        }
    }
}