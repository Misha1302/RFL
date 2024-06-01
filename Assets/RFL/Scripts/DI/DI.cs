namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;

    public class Di : SingletonBase<Di>
    {
        private readonly Dictionary<Type, Lazy<Any>> _singletons = new();

        public void AddSingle<TSingleton>(TSingleton singleton) =>
            AddLazySingle(() => singleton);

        public void AddLazySingle<TSingleton>(Func<TSingleton> lazyFunc) =>
            _singletons[typeof(TSingleton)] = new Lazy<Any>(() => new Any(lazyFunc()));


        [Pure] public TSingleton GetSingle<TSingleton>()
        {
            if (!_singletons.TryGetValue(typeof(TSingleton), out var lazy))
                Thrower.InvalidOpEx($"Could not found {typeof(TSingleton).Name}");

            var value = lazy.Value.Get<TSingleton>();
            if (value == null)
                Thrower.InvalidOpEx($"Value of {typeof(TSingleton).Name} was null");

            return value;
        }

        [Pure] public static TSingleton Get<TSingleton>() => Instance.GetSingle<TSingleton>();
    }
}