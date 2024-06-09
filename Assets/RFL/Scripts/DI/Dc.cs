namespace RFL.Scripts.DI
{
    using System;
    using System.Diagnostics.Contracts;
    using RFL.Scripts.Singletons;

    public class Dc : SingletonBase<Dc>
    {
        private readonly RawDc _rawDc = new();

        public void AddLazySingle<TSingleton>(Func<TSingleton> func) =>
            _rawDc.AddLazySingleScoped(func);

        public void AddSingle<TSingleton>(TSingleton value) =>
            _rawDc.AddLazySingleScoped(() => value);

        public void AddLazySingleScoped<TScope, TSingleton>(Func<TSingleton> func) =>
            _rawDc.AddLazySingleScoped(func);

        [Pure] public TSingleton GetSingle<TSingleton>() =>
            (TSingleton)_rawDc.GetSingle(typeof(TSingleton));

        [Pure] public object GetSingle(Type type) =>
            _rawDc.GetSingle(type);
    }
}