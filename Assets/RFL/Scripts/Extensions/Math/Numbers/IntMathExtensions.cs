namespace RFL.Scripts.Extensions.Math.Numbers
{
    using System;
    using UnityEngine;

    public static class IntMathExtensions
    {
        public static int Min(this int value, int value2) => Mathf.Min(value, value2);
        public static int RoundStep(this int value, int step) => value / step * step;

        public static int ThisOrIf(this int value, Predicate<int> condition, int ifValue) =>
            condition(value) ? ifValue : value;
    }
}