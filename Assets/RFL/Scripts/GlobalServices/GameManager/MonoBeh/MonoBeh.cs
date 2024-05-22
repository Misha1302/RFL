namespace RFL.Scripts.GlobalServices.GameManager.MonoBeh
{
    using RFL.Scripts.DI;
    using UnityEngine;

    public abstract class MonoBeh : ComponentsKeeper
    {
        public bool isEnabled = true;

        private void Awake()
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

        public virtual void OnStart() { }

        public virtual void Tick() { }

        public virtual void LateTick() { }

        public virtual void FixedTick() { }

        public virtual void OnColEnter2D(Collision2D other) { }

        public virtual void OnColStay2D(Collision2D other) { }

        public virtual void OnColExit2D(Collision2D other) { }

        public virtual void SelfDestroy()
        {
            Di.Instance.GetGlobalSingleton<GameService>().RemoveMonoBeh(this);
        }
    }
}