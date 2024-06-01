namespace RFL.Scripts.GlobalServices.Repository
{
    using System;
    using RFL.Scripts.GameLogic.Plants.Trees;

    [Serializable]
    public class SceneData
    {
        public SerializableDictionary<SerializableGuid, TreeData> treesData = new();
    }
}