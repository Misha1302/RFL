namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using RFL.Scripts.DI.Scopes;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;

    public class Di : SingletonBase<Di>, IDi
    {
        private readonly Dictionary<Type, Dictionary<Type, Lazy<Any>>> _scopes = new();


        public void AddGlobalSingleton<TSingleton>(TSingleton singleton) =>
            AddScopedSingleton<GlobalScope, TSingleton>(singleton);

        public TSingleton GetGlobalSingleton<TSingleton>() =>
            GetScopedSingleton<GlobalScope, TSingleton>();


        public void AddScopedSingleton<TScope, TSingleton>(TSingleton singleton) where TScope : IScope =>
            AddScopedSingleton<TScope, TSingleton>(() => singleton);

        public TSingleton GetScopedSingleton<TScope, TSingleton>() where TScope : IScope =>
            Scope<TScope>()[typeof(TSingleton)].Value.Get<TSingleton>() ??
            Thrower.InvalidOpEx("Value is null").Get<TSingleton>();

        public void AddGlobalSingleton<TSingleton>(Func<TSingleton> lazyFunc) =>
            AddScopedSingleton<GlobalScope, TSingleton>(lazyFunc);


        public void AddScopedSingleton<TScope, TSingleton>(Func<TSingleton> lazyFunc) where TScope : IScope =>
            GetOrAddScope<TScope>()[typeof(TSingleton)] = new Lazy<Any>(() => new Any(lazyFunc()));


        private Dictionary<Type, Lazy<Any>> GetOrAddScope<TScope>() where TScope : IScope
        {
            if (!_scopes.TryGetValue(typeof(TScope), out var value))
                _scopes[typeof(TScope)] = value = new Dictionary<Type, Lazy<Any>>();
            return value;
        }

        private Dictionary<Type, Lazy<Any>> Scope<TScope>() where TScope : IScope =>
            _scopes[typeof(TScope)] ??
            Thrower.InvalidOpEx($"Scope {typeof(TScope)} does not exists").Get<Dictionary<Type, Lazy<Any>>>();
    }
}