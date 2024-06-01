﻿namespace RFL.Scripts.GlobalServices.Repository
{
    using System;

    [Serializable]
    public class SerializableKeyValuePair<T, T1>
    {
        public T key;
        public T1 value;

        public SerializableKeyValuePair(T key, T1 value)
        {
            this.key = key;
            this.value = value;
        }
    }
}