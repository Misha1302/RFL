namespace RFL.Scripts.DI
{
    using System.Collections.Generic;
    using System.Linq;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using UnityEngine;

    public class DependencyInjector : SelfSingletonBase<DependencyInjector>
    {
        private readonly Dc _container;

        public DependencyInjector(Dc container)
        {
            _container = container;
        }

        public static void CreateSingleton(Dc container)
        {
            _ = new DependencyInjector(container);
        }

        public void Inject(GameObject gameObject)
        {
            gameObject.GetComponents<Component>().ForAll(Inject);
        }

        public void Inject(Component component)
        {
            var initMethod = component.GetType().GetMethods()
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(InjectMethodAttribute), false).Any());

            if (initMethod == null)
                return;

            var parameters = new List<object>();
            initMethod.GetParameters().ForAll(x => parameters.Add(_container.GetSingle(new Types(x.ParameterType))));

            initMethod.Invoke(component, parameters.ToArray());
        }
    }
}