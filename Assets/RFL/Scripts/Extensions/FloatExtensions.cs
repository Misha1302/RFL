namespace RFL.Scripts.Extensions
{
    public static class FloatExtensions
    {
        public static string ToStr(this float value, string format = "0.###") =>
            value.ToString(format);
    }
}