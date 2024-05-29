namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.DI;
    using UnityEngine;

    public abstract class MonoBeh : ComponentsKeeper
    {
        public bool isEnabled = true;


        protected void Awake()
        {
            if (isEnabled)
                Di.Get<GameService>().AddMonoBeh(this);
            OnCreated();
        }

        private void Update()
        {
            TickAnyway();
        }

        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            if (isEnabled)
                OnColEnter2D(other);
        }

        public virtual void OnCollisionExit2D(Collision2D other)
        {
            if (isEnabled)
                OnColExit2D(other);
        }

        public virtual void OnCollisionStay2D(Collision2D other)
        {
            if (isEnabled)
                OnColStay2D(other);
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
        protected virtual void OnColEnter2D(Collision2D other) { }
        protected virtual void OnColStay2D(Collision2D other) { }
        protected virtual void OnColExit2D(Collision2D other) { }

        public virtual void SelfDestroy()
        {
            isEnabled = false;
            Di.Get<GameService>().RemoveMonoBeh(this);
        }
    }
}