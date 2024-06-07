namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.Contracts;
    using RFL.Scripts.Helpers;
    using RFL.Scripts.Singletons;

    public class RawDc
    {
        private readonly Dictionary<Types, Lazy<Any>> _singletons = new();

        public void AddLazySingleScoped<TScope, TSingleton>(Func<TSingleton> func) =>
            _singletons.Add(new Types(typeof(TScope)), new Lazy<Any>(() => new Any(func())));

        [Pure] public object GetSingle(Types types)
        {
            if (!_singletons.TryGetValue(types, out var lazy))
                Thrower.InvalidOpEx($"Could not found {types}");

            var value = lazy.Value.Get();
            if (value == null)
                Thrower.InvalidOpEx($"Value of {types} was null");
            return value;
        }
    }

    public class Dc : SingletonBase<Dc>
    {
        private readonly RawDc _rawDc = new();

        public void AddLazySingle<TSingleton>(Func<TSingleton> func) =>
            _rawDc.AddLazySingleScoped<GlobalScope, TSingleton>(func);

        public void AddLazySingleScoped<TScope, TSingleton>(Func<TSingleton> func) =>
            _rawDc.AddLazySingleScoped<TScope, TSingleton>(func);

        [Pure] public TSingleton GetSingle<TSingleton>() =>
            (TSingleton)_rawDc.GetSingle(new Types(typeof(GlobalScope), typeof(TSingleton)));

        [Pure] public object GetSingle(Types types) =>
            _rawDc.GetSingle(types);
    }
}