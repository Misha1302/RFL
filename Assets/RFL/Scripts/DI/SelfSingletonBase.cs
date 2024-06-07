namespace RFL.Scripts.DI
{
    public class SelfSingletonBase<T>
    {
        protected SelfSingletonBase()
        {
            Instance = (T)(object)this;
        }

        public static T Instance { get; private set; }
    }
}