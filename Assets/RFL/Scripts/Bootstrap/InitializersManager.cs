namespace RFL.Scripts.Bootstrap
{
    using System;
    using System.Linq;
    using System.Reflection;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;

    public static class InitializersManager
    {
        public static void InitEveryIntializer()
        {
            var initializers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.Public)
                    .Where(m => m.GetCustomAttributes<InitializerMethodAttribute>().Any())
                ).OrderBy(x => x.GetCustomAttribute<InitializerMethodAttribute>().Priority);

            initializers.ForAll(x =>
            {
                var instance = Activator.CreateInstance(x.DeclaringType!);
                x.Invoke(instance, null);
            });
        }
    }
}