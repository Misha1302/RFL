namespace RFL.Scripts.Extensions
{
    using UnityEngine;

    public static class MathExtensions
    {
        public static float Abs(this float value) => Mathf.Abs(value);
        public static float ClampNeg10(this float value) => Mathf.Clamp(value, -1, 0);
        public static float Clamp01(this float value) => Mathf.Clamp(value, 0, 1);
        public static float PingPong(this float value, float repeatValue) => Mathf.PingPong(value, repeatValue);
        public static float Max(this float value, float value2) => Mathf.Max(value, value2);

        public static float MoveTowards(this float current, float target, float maxDelta) =>
            Mathf.MoveTowards(current, target, maxDelta);
    }
}