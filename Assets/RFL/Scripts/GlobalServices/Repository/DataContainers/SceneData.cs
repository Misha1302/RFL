namespace RFL.Scripts.GlobalServices.Repository.DataContainers
{
    using System;
    using RFL.Scripts.DependenciesManagement.Container;
    using RFL.Scripts.GlobalServices.Repository.DataContainers.Primitives;

    [Serializable]
    public class SceneData
    {
        public EventSerializableDictionary<SerializableGuid, Any> data = new();
    }
}