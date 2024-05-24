namespace RFL.Scripts.Extensions
{
    using Unity.VisualScripting;
    using UnityEngine;

    public static class ComponentsExtensions
    {
        public static bool HasComponent<T>(this Component component) where T : Component =>
            component.TryGetComponent<T>(out _);

        public static T GetOrAddComponent<T>(this Component component) where T : Component
        {
            if (!component.TryGetComponent<T>(out var value))
                value = component.AddComponent<T>();
            return value;
        }
    }
}