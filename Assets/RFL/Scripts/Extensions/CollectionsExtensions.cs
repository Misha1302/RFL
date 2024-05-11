namespace RFL.Scripts.Extensions
{
    using System;
    using System.Collections.Generic;

    public static class CollectionsExtensions
    {
        public static void ForAll<T>(this IReadOnlyList<T> lst, Action<T> act)
        {
            // ReSharper disable once ForCanBeConvertedToForeach
            for (var index = 0; index < lst.Count; index++)
                act(lst[index]);
        }
    }
}