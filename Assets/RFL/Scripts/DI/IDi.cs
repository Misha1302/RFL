namespace RFL.Scripts.DI
{
    using System;
    using RFL.Scripts.DI.Scopes;

    public interface IDi
    {
        public void AddGlobalSingleton<TSingleton>(TSingleton singleton);
        public void AddGlobalSingleton<TSingleton>(Func<TSingleton> lazyFunc);
        public void AddScopedSingleton<TScope, TSingleton>(TSingleton singleton) where TScope : IScope;
        public void AddScopedSingleton<TScope, TSingleton>(Func<TSingleton> lazyFunc) where TScope : IScope;

        public TSingleton GetGlobalSingleton<TSingleton>();
        public TSingleton GetScopedSingleton<TScope, TSingleton>() where TScope : IScope;
    }
}