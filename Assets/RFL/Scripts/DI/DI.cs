namespace RFL.Scripts.DI
{
    using System;
    using System.Diagnostics.Contracts;
    using RFL.Scripts.DI.Scopes;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;
    using SingletonsT = System.Collections.Generic.Dictionary<System.Type, System.Lazy<Any>>;
    using ScopesT =
        System.Collections.Generic.Dictionary<System.Type,
            System.Collections.Generic.Dictionary<System.Type, System.Lazy<Any>>>;

    public class Di : SingletonBase<Di>
    {
        private readonly ScopesT _scopes = new();

        public void AddGlobalSingleton<TSingleton>(TSingleton singleton) =>
            AddScopedSingleton<GlobalScope, TSingleton>(singleton);

        [Pure] public TSingleton GetGlobalSingleton<TSingleton>() =>
            GetScopedSingleton<GlobalScope, TSingleton>();


        public void AddScopedSingleton<TScope, TSingleton>(TSingleton singleton) where TScope : IScope =>
            AddScopedSingleton<TScope, TSingleton>(() => singleton);

        [Pure] public TSingleton GetScopedSingleton<TScope, TSingleton>() where TScope : IScope =>
            Scope<TScope>()[typeof(TSingleton)].Value.Get<TSingleton>() ??
            Thrower.InvalidOpEx("Value is null").Get<TSingleton>();

        public void AddGlobalSingleton<TSingleton>(Func<TSingleton> lazyFunc) =>
            AddScopedSingleton<GlobalScope, TSingleton>(lazyFunc);


        public void AddScopedSingleton<TScope, TSingleton>(Func<TSingleton> lazyFunc) where TScope : IScope =>
            GetOrAddScope<TScope>()[typeof(TSingleton)] = new Lazy<Any>(() => new Any(lazyFunc()));


        private SingletonsT GetOrAddScope<TScope>() where TScope : IScope
        {
            if (!_scopes.TryGetValue(typeof(TScope), out var value))
                _scopes[typeof(TScope)] = value = new SingletonsT();
            return value;
        }

        private SingletonsT Scope<TScope>() where TScope : IScope =>
            _scopes[typeof(TScope)] ??
            Thrower.InvalidOpEx($"Scope {typeof(TScope)} does not exists").Get<SingletonsT>();


        [Pure] public static TSingleton Get<TSingleton>() => Instance.GetGlobalSingleton<TSingleton>();

        [Pure] public static TSingleton Get<TScope, TSingleton>() where TScope : IScope =>
            Instance.GetScopedSingleton<TScope, TSingleton>();
    }
}