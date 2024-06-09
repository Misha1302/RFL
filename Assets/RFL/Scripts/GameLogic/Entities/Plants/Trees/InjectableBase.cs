namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using RFL.Scripts.DI;

    public abstract class InjectableBase
    {
        protected InjectableBase()
        {
            DependencyInjector.Instance.Inject(this);
        }
    }
}