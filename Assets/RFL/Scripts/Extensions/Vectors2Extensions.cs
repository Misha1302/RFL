namespace RFL.Scripts.Extensions
{
    using UnityEngine;

    public static class Vectors2Extensions
    {
        public static Vector3 WithX(this Vector2 vec, float x)
        {
            vec.x = x;
            return vec;
        }

        public static Vector3 WithY(this Vector2 vec, float y)
        {
            vec.y = y;
            return vec;
        }
    }
}