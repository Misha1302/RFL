namespace RFL.Scripts.Helpers
{
    using System;
    using System.Linq;
    using RFL.Scripts.DI;
    using UnityEngine;
    using Component = UnityEngine.Component;
    using Object = UnityEngine.Object;

    public class CreatorService
    {
        private const string Prefix = "__";

        private readonly Dc _container;

        public T Instantiate<T>(T prefab) where T : Object => Object.Instantiate(prefab);

        public T Create<T>() where T : Component =>
            Create(typeof(T)).GetComponent<T>();

        public T2 Create<T, T2>() where T : Component where T2 : Component =>
            Create(typeof(T), typeof(T2)).GetComponent<T2>();

        private GameObject Create(params Type[] ts) => new(MakeName(ts), ts);

        private string MakeName(params Type[] types) =>
            $"{Prefix}({string.Join("; ", types.Select(x => x.Name))})";
    }
}