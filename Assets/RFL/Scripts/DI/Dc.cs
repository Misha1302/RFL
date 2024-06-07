namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;

    public class Dc : SingletonBase<Dc>
    {
        private readonly Dictionary<Type, Lazy<Any>> _singletons = new();

        public void AddSingle<TSingleton>(TSingleton singleton) =>
            AddLazySingle(() => singleton);

        public void AddLazySingle<TSingleton>(Func<TSingleton> lazyFunc) =>
            _singletons[typeof(TSingleton)] = new Lazy<Any>(() => new Any(lazyFunc()));


        [Pure] public TSingleton GetSingle<TSingleton>() =>
            (TSingleton)GetSingle(typeof(TSingleton));

        [Pure] public object GetSingle(Type type)
        {
            if (!_singletons.TryGetValue(type, out var lazy))
                Thrower.InvalidOpEx($"Could not found {type.Name}");

            var value = lazy.Value.Get();
            if (value == null)
                Thrower.InvalidOpEx($"Value of {type.Name} was null");
            return value;
        }

        [Pure] public static TSingleton Get<TSingleton>() => Instance.GetSingle<TSingleton>();
    }
}