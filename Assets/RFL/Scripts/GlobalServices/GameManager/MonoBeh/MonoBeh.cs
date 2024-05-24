namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.DI;
    using UnityEngine;

    public abstract class MonoBeh : ComponentsKeeper
    {
        public bool isEnabled = true;

        protected virtual void Awake()
        {
            if (isEnabled)
                Services.GameService.AddMonoBeh(this);
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
        protected virtual void LateTick() { }
        protected virtual void FixedTick() { }
        protected virtual void OnColEnter2D(Collision2D other) { }
        protected virtual void OnColStay2D(Collision2D other) { }
        protected virtual void OnColExit2D(Collision2D other) { }

        public virtual void SelfDestroy()
        {
            Di.Instance.GetGlobalSingleton<GameService>().RemoveMonoBeh(this);
        }
    }
}