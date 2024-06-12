namespace RFL.Scripts.Bootstrap
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GameLogic.Scenes;
    using RFL.Scripts.GlobalServices.Repository.DataContainers;

    public static class InitializersManager
    {
        private static readonly HashSet<MethodInfo> _initialized = new();

        public static void InitEveryIntializer(SceneName currentSceneName)
        {
            var initializers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(type =>
                    type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                        .Where(m => m.GetCustomAttributes<SceneInitializerAttribute>().Any())
                )
                .Select(x => (method: x, attribute: x.GetCustomAttribute<SceneInitializerAttribute>()))
                .OrderBy(x => x.attribute.Priority);

            initializers.ForAll(x =>
            {
                var instance = Activator.CreateInstance(x.method.DeclaringType!);
                var attr = x.attribute;

                if (attr.SceneNameType != typeof(AnyScene) && attr.SceneNameType != currentSceneName.GetType())
                    return;
                if (attr.InitializationType == InitializationType.Once && _initialized.Contains(x.method))
                    return;

                _initialized.Add(x.method);
                x.method.Invoke(instance, null);
            });
        }
    }
}