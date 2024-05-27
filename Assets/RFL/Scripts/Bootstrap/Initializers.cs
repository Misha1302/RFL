namespace RFL.Scripts.Bootstrap
{
    using System.Linq;
    using System.Reflection;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;

    public static class Initializers
    {
        public static void InitEvery()
        {
            var initializers = Assembly.GetExecutingAssembly()
                .GetTypes()
                .SelectMany(type =>
                    type.GetMethods(BindingFlags.Static | BindingFlags.Public)
                        .Where(m => m.GetCustomAttributes<InitializerMethodAttribute>().Any())
                );


            initializers.ForAll(x => x.Invoke(null, null));
        }
    }
}