namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.DI;

    public abstract class MonoBeh : ComponentsKeeper
    {
        public bool isEnabled = true;
        protected CollisionDetector CollisionDetector;


        protected void Awake()
        {
            if (isEnabled)
                Di.Get<GameService>().AddMonoBeh(this);
            if (!transform.TryGetComponent(out CollisionDetector))
                CollisionDetector = gameObject.AddComponent<CollisionDetector>();
            OnCreated();
        }

        private void Update()
        {
            TickAnyway();
        }

        protected virtual void OnCreated() { }

        public void PubOnStart()
        {
            if (isEnabled)
                OnStart();
        }

        public void PubTick()
        {
            if (isEnabled)
                Tick();
        }

        public void PubLateTick()
        {
            if (isEnabled)
                LateTick();
        }

        public void PubFixedTick()
        {
            if (isEnabled)
                FixedTick();
        }

        protected virtual void OnStart() { }
        protected virtual void Tick() { }
        protected virtual void TickAnyway() { }
        protected virtual void LateTick() { }
        protected virtual void FixedTick() { }

        public virtual void SelfDestroy()
        {
            isEnabled = false;
            Di.Get<GameService>().RemoveMonoBeh(this);
        }
    }
}