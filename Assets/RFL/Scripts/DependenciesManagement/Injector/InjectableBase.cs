namespace RFL.Scripts.DependenciesManagement.Injector
{
    using RFL.Scripts.Singletons;

    public abstract class InjectableBase
    {
        protected InjectableBase()
        {
            GameSingletons.DependencyInjector.Inject(this);
        }
    }
}