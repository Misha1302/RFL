namespace RFL.Scripts.GameManager
{
    using RFL.Scripts.DI;

    public abstract class MonoBeh : ComponentsKeeper
    {
        private void Awake()
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