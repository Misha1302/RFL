namespace RFL.Scripts.DependenciesManagement.Container
{
    using System;

    public class DependencyContainer : RawDependencyContainer
    {
        public void AddSingle<TSingleton>(TSingleton value) =>
            AddSingleScoped<IAnyScope, TSingleton>(value);

        public void AddSingleScoped<TScope, TSingleton>(TSingleton value) =>
            AddLazySingleScoped<TScope, TSingleton>(() => value);


        public void AddLazySingle<TSingleton>(Func<TSingleton> func) =>
            AddLazySingleScoped<IAnyScope, TSingleton>(func);
    }
}