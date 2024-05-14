namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using RFL.Scripts.DI.Scopes;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;

    public class Di : SingletonBase<Di>
    {
        private readonly Dictionary<Type, Dictionary<Type, Lazy<Any>>> _scopes = new();


        public void AddGlobalSingleton<TSingleton>(TSingleton singleton) =>
            AddScopedSingleton<GlobalScope, TSingleton>(singleton);

        public TSingleton GetGlobalSingleton<TSingleton>() =>
            GetScopedSingleton<GlobalScope, TSingleton>();


        public void AddScopedSingleton<TScope, TSingleton>(TSingleton singleton) =>
            AddScopedSingleton<TScope, TSingleton>(() => singleton);

        public TSingleton GetScopedSingleton<TScope, TSingleton>() =>
            Score<TScope>()[typeof(TSingleton)].Value.Get<TSingleton>();

        public void AddGlobalSingleton<TSingleton>(Func<TSingleton> lazyFunc) =>
            AddScopedSingleton<GlobalScope, TSingleton>(lazyFunc);


        public void AddScopedSingleton<TScope, TSingleton>(Func<TSingleton> lazyFunc) =>
            GetOrAddScope<TScope>()[typeof(TSingleton)] = new Lazy<Any>(() => new Any(lazyFunc()));


        private Dictionary<Type, Lazy<Any>> GetOrAddScope<TScope>()
        {
            if (!_scopes.TryGetValue(typeof(TScope), out var value))
                _scopes[typeof(TScope)] = value = new Dictionary<Type, Lazy<Any>>();
            return value;
        }

        private Dictionary<Type, Lazy<Any>> Score<TScope>() =>
            _scopes[typeof(TScope)] ??
            Thrower.InvalidOpEx($"Scope {typeof(TScope)} does not exists").Get<Dictionary<Type, Lazy<Any>>>();
    }
}