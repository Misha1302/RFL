namespace RFL.Scripts.Helpers
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using RFL.Scripts.DI;

    public static class Thrower
    {
        [DoesNotReturn]
        public static Any InvalidOpEx(string msg) => throw new InvalidOperationException(msg);

        public static Any InvalidOpExIf([DoesNotReturnIf(true)] bool isNeedToThrow, string msg) =>
            isNeedToThrow ? InvalidOpEx(msg) : new Any(null);
    }
}