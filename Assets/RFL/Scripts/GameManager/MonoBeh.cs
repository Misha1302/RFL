namespace RFL.Scripts.GameManager
{
    using RFL.Scripts.DI;
    using UnityEngine;

    public abstract class MonoBeh : ComponentsKeeper
    {
        private void Awake()
        {
            Services.GameService.AddMonoBeh(this);
        }

        public virtual void OnCollisionEnter2D(Collision2D other)
        {
            OnColEnter2D(other);
        }

        public virtual void OnCollisionStay2D(Collision2D other)
        {
            OnColStay2D(other);
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

        public virtual void OnColEnter2D(Collision2D other)
        {
        }

        public virtual void OnColStay2D(Collision2D other)
        {
        }

        public virtual void OnColLeave2D(Collision2D other)
        {
        }

        public virtual void OnCollisionLeave2D(Collision2D other)
        {
            OnColLeave2D(other);
        }

        public virtual void SelfDestroy()
        {
            Di.Instance.GetGlobalSingleton<GameService>().RemoveMonoBeh(this);
        }
    }
}