namespace RFL.Scripts.GameManager
{
    using RFL.Scripts.DI;
    using UnityEngine;

    public abstract class MonoBeh : MonoBehaviour
    {
        protected MonoBeh()
        {
            Di.Instance.GetGlobalSingleton<GameManager>().AddMonoBeh(this);
        }

        public virtual void Tick()
        {
        }

        public virtual void LateTick()
        {
        }

        public virtual void FixedTick()
        {
        }

        public virtual void SelfDestroy()
        {
            Di.Instance.GetGlobalSingleton<GameManager>().RemoveMonoBeh(this);
        }
    }
}