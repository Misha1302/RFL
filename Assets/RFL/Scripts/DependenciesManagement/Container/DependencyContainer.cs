namespace RFL.Scripts.DependenciesManagement.Container
{
    public class DependencyContainer : RawDependencyContainer
    {
        public void AddSingle<TSingleton>(TSingleton value) =>
            AddLazySingle(() => value);
    }
}