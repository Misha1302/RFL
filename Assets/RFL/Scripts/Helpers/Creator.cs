namespace RFL.Scripts.Helpers
{
    using System;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public static class Creator
    {
        private const string Prefix = "__";

        public static T Instantiate<T>(T prefab) where T : Object => Object.Instantiate(prefab);

        public static T Create<T>() where T : Component =>
            Create(typeof(T)).GetComponent<T>();

        public static T2 Create<T, T2>() where T : Component where T2 : Component =>
            Create(typeof(T), typeof(T2)).GetComponent<T2>();

        private static GameObject Create(params Type[] ts) => new(MakeName(ts), ts);

        private static string MakeName(params Type[] types) =>
            $"{Prefix}({string.Join("; ", types.Select(x => x.Name))})";

        public static void Destroy(Transform transform)
        {
            var monoBehs = transform.GetComponentsInChildren<MonoBeh>(true);
            monoBehs.ForAll(x => x.SelfDestroy());
            Object.Destroy(transform.gameObject);
        }
    }
}