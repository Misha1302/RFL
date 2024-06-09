namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using RFL.Scripts.Helpers;

    public class RawDc
    {
        private readonly Dictionary<Type, Lazy<Any>> _singletons = new();

        public void AddLazySingleScoped<TSingleton>(Func<TSingleton> func)
        {
            _singletons[typeof(TSingleton)] = new Lazy<Any>(() => new Any(func()));
        }

        [Pure] public object GetSingle(Type type)
        {
            if (!_singletons.TryGetValue(type, out var lazy))
                Thrower.InvalidOpEx($"Could not found {type}");

            var value = lazy.Value.Get();
            if (value == null)
                Thrower.InvalidOpEx($"Value of {type} was null");
            return value;
        }
    }
}