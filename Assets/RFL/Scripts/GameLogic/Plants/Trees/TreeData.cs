namespace RFL.Scripts.GameLogic.Plants.Trees
{
    using System;
    using UnityEngine;

    [Serializable]
    public class TreeData
    {
        public long ticksCountWhenTreeWasGrown;
        public Vector3 position;
        public SerializableGuid id;

        public TreeData(long ticksCountWhenTreeWasGrown, Vector3 position, SerializableGuid id)
        {
            this.ticksCountWhenTreeWasGrown = ticksCountWhenTreeWasGrown;
            this.position = position;
            this.id = id;
        }
    }
}