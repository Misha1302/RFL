namespace RFL.Scripts.DI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Entities.Plants.Trees;
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

        public void Inject(Component component) => Inject((object)component);

        public void Inject(InjectableBase injectableBase) => Inject((object)injectableBase);

        private void Inject(object injectable)
        {
            InjectViaFields(injectable);
            InjectViaMethod(injectable);
        }

        private void InjectViaFields(object component)
        {
            var fieldInfos = GetTypesRecursivelyToParent(component).SelectMany(t =>
                    t.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                        .Where(x => x.GetCustomAttributes(typeof(InjectAttribute), false).Any())
                )
                .ToArray();

            if (!fieldInfos.Any())
                return;

            fieldInfos.ForAll(x =>
                x.SetValue(component, _container.GetSingle(x.FieldType))
            );
        }

        private List<Type> GetTypesRecursivelyToParent(object component)
        {
            var types = new List<Type> { component.GetType() };
            GetTypesRecursivelyToParentInternal(component.GetType());
            return types;

            void GetTypesRecursivelyToParentInternal(Type type)
            {
                var parent = type.BaseType;
                if (parent == null) return;

                types.Add(parent);
                GetTypesRecursivelyToParentInternal(type.BaseType);
            }
        }

        private void InjectViaMethod(object component)
        {
            var initMethod = component.GetType().GetMethods()
                .FirstOrDefault(x => x.GetCustomAttributes(typeof(InjectAttribute), false).Any());

            if (initMethod == null)
                return;

            var parameters = new List<object>();
            initMethod.GetParameters().ForAll(x => parameters.Add(_container.GetSingle(x.ParameterType)));

            initMethod.Invoke(component, parameters.ToArray());
        }
    }
}