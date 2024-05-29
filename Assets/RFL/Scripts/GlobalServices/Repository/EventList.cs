namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    [Serializable]
    public class EventList<T>
    {
        [SerializeField] private List<T> list = new();

        public Action<EventList<T>> OnChanged = null!;

        public void AddRange(IEnumerable<T> range)
        {
            list.AddRange(range);
            OnChanged?.Invoke(this);
        }

        public void Clear()
        {
            list.Clear();
            OnChanged?.Invoke(this);
        }
    }
}