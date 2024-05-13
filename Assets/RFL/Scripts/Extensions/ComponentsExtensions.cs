namespace RFL.Scripts.Extensions
{
    using UnityEngine;

    public static class ComponentsExtensions
    {
        public static bool HasComponent<T>(this Component component) => component.TryGetComponent<T>(out _);
    }
}