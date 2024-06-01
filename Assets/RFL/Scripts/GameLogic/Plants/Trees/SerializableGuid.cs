namespace RFL.Scripts.GameLogic.Plants.Trees
{
    using System;
    using UnityEngine;

    /// <summary>
    ///     <a href="https://forum.unity.com/threads/cannot-serialize-a-guid-field-in-class.156862/">
    ///         code taken from here
    ///     </a>
    ///     Author: Searous
    /// </summary>
    [Serializable]
    public struct SerializableGuid : ISerializationCallbackReceiver
    {
        [SerializeField] private string serializedGuid;
        private Guid _guid;

        public SerializableGuid(Guid guid)
        {
            _guid = guid;
            serializedGuid = null;
        }

        public void OnAfterDeserialize()
        {
            _guid = Guid.Parse(serializedGuid);
        }

        public void OnBeforeSerialize()
        {
            serializedGuid = _guid.ToString();
        }

        public override bool Equals(object obj) =>
            obj is SerializableGuid guid &&
            _guid.Equals(guid._guid);

        public override int GetHashCode() => -1324198676 + _guid.GetHashCode();

        public override string ToString() => _guid.ToString();

        public static bool operator ==(SerializableGuid a, SerializableGuid b) => a._guid == b._guid;
        public static bool operator !=(SerializableGuid a, SerializableGuid b) => a._guid != b._guid;
        public static implicit operator SerializableGuid(Guid guid) => new(guid);
        public static implicit operator Guid(SerializableGuid serializable) => serializable._guid;
        public static implicit operator SerializableGuid(string serializedGuid) => new(Guid.Parse(serializedGuid));
        public static implicit operator string(SerializableGuid serializedGuid) => serializedGuid.ToString();
    }
}