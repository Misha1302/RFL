namespace RFL.Scripts.Extensions
{
    using System.Collections.Generic;

    public static class ValuesExtensions
    {
        public static bool Eq<T>(this T a, T b) =>
            EqualityComparer<T>.Default.Equals(a, b);
    }
}