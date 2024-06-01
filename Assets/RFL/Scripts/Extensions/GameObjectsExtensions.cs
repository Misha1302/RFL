namespace RFL.Scripts.Extensions
{
    using System.Linq;
    using UnityEngine;

    public static class GameObjectsExtensions
    {
        public static float CalcHalfOfVisibleYSize(this GameObject gameObject)
        {
            return gameObject
                .GetComponentsInChildren<SpriteRenderer>()
                .Max(r => r.size.y * r.transform.localScale.y) / 2;
        }
    }
}