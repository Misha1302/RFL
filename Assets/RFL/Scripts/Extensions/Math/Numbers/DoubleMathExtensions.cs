namespace RFL.Scripts.Extensions.Math.Numbers
{
    using System;

    public static class DoubleMathExtensions
    {
        private const float DefaultTolerance = 0.0001f;

        public static bool ApproxEq(this double value, double value2, double tolerance = DefaultTolerance) =>
            Math.Abs(value - value2) < tolerance;
    }
}