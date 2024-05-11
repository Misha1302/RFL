namespace RFL.Scripts.Singletons
{
    using System;

    public class SingletonBase<TSelf> where TSelf : new()
    {
        private static readonly Lazy<TSelf> _lazyInstance = new(() => new TSelf());
        public static TSelf Instance => _lazyInstance.Value;
    }
}