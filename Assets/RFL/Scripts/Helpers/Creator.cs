namespace RFL.Scripts.Helpers
{
    using Unity.VisualScripting;
    using UnityEngine;
    using Object = UnityEngine.Object;

    public static class Creator
    {
        public static T Instantiate<T>(T prefab) where T : Object => Object.Instantiate(prefab);


        public static T Create<T>() where T : Component =>
            new GameObject(MakeName<T>()).AddComponent<T>();

        public static T2 Create<T, T2>() where T : Component where T2 : Component =>
            new GameObject(MakeName<T, T2>()).AddComponent<T>().AddComponent<T2>();


        private static string MakeName<T>() => typeof(T).ToString();
        private static string MakeName<T, T2>() => $"{typeof(T)}; {typeof(T2)}";
    }
}