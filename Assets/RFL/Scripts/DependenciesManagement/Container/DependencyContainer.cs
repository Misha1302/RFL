namespace RFL.Scripts.DependenciesManagement.Container
{
    using System;

    public class DependencyContainer : RawDependencyContainer
    {
        public void AddSingle<TSingleton>(TSingleton value) =>
            AddSingleScoped<IAnyScope, TSingleton>(value);

        public void AddSingleScoped<TScope, TSingleton>(TSingleton value) =>
            AddSingleScoped<TScope, TSingleton>(() => value);

        public void AddLazySingleScoped<TScope, TSingleton>(Func<TSingleton> value) =>
            AddSingleScoped<TScope, Lazy<TSingleton>>(() => new Lazy<TSingleton>(value));

        public void AddLazySingle<TSingleton>(Func<TSingleton> value) =>
            AddSingleScoped<IAnyScope, Lazy<TSingleton>>(() => new Lazy<TSingleton>(value));

        public void AddSingle<TSingleton>(Func<TSingleton> func) =>
            AddSingleScoped<IAnyScope, TSingleton>(func);
    }
}