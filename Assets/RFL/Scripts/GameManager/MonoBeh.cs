namespace RFL.Scripts.GameManager
{
    using RFL.Scripts.DI;

    public abstract class MonoBeh : ComponentsKeeper
    {
        private void Awake()
        {
            Services.GameService.AddMonoBeh(this);
        }

        public virtual void OnStart()
        {
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
            Di.Instance.GetGlobalSingleton<GameService>().RemoveMonoBeh(this);
        }
    }
}