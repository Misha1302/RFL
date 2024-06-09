namespace RFL.Scripts.Attributes
{
    using System;

    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Field)]
    public sealed class InjectAttribute : Attribute { }
}