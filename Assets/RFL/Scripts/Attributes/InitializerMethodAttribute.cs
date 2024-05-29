namespace RFL.Scripts.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method)]
    public sealed class InitializerMethodAttribute : Attribute
    {
        public readonly int Priority;

        public InitializerMethodAttribute(int priority = 0)
        {
            Priority = priority;
        }
    }
}