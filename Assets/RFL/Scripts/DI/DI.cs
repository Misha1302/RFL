namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using RFL.Scripts.DI.Scopes;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;

    public class Di : SingletonBase<Di>, IDependencyKeeper
    {
        private readonly Dictionary<Type, Dictionary<Type, Lazy<Any>>> _scopes = new();


        public void AddGlobalSingleton<TSingleton>(TSingleton singleton) =>
            AddScopedSingleton<GlobalScope, TSingleton>(singleton);

        public TSingleton GetGlobalSingleton<TSingleton>() =>
            GetScopedSingleton<GlobalScope, TSingleton>();


        public void AddScopedSingleton<TScope, TSingleton>(TSingleton singleton) =>
            GetOrAddScope<TScope>()[typeof(TSingleton)] = new Lazy<Any>(() => new Any(singleton));

        public TSingleton GetScopedSingleton<TScope, TSingleton>() =>
            Score<TScope>()[typeof(TSingleton)].Value.Get<TSingleton>();


        private Dictionary<Type, Lazy<Any>> GetOrAddScope<TScope>() =>
            _scopes[typeof(TScope)] ??= new Dictionary<Type, Lazy<Any>>();

        private Dictionary<Type, Lazy<Any>> Score<TScope>() =>
            _scopes[typeof(TScope)] ??
            Thrower.InvalidOpEx($"Scope {typeof(TScope)} does not exists").Get<Dictionary<Type, Lazy<Any>>>();
    }
}