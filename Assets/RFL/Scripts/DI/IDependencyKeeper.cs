namespace RFL.Scripts.DI
{
    public interface IDependencyKeeper
    {
        public void AddGlobalSingleton<TSingleton>(TSingleton singleton);
        public void AddScopedSingleton<TScope, TSingleton>(TSingleton singleton);

        public TSingleton GetGlobalSingleton<TSingleton>();
        public TSingleton GetScopedSingleton<TScope, TSingleton>();
    }
}