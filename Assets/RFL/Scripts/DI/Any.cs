namespace RFL.Scripts.DI
{
    public class Any
    {
        private readonly object _obj;

        public Any(object obj)
        {
            _obj = obj;
        }

        public T Get<T>() => (T)_obj;
    }
}