namespace RFL.Scripts.DI
{
    using System;
    using RFL.Scripts.Extensions;
    using UnityEngine;

    [Serializable]
    public class Any
    {
        [SerializeReference] private object obj;

        public Any(object obj)
        {
            this.obj = obj;
        }

        public T Get<T>() => (T)obj;
        public bool TryGet<T>(out T value) => (value = obj is T castedObj ? castedObj : default).Eq(default);

        public bool Is<T>() => obj is T;
    }
}