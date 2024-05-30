namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using UnityEngine;

    [Serializable]
    public class EventField<T>
    {
        [SerializeField] private T value;

        public Action OnChanged = null!;

        public T Value
        {
            get => value;
            set
            {
                this.value = value;
                OnChanged?.Invoke();
            }
        }
    }
}