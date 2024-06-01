namespace RFL.Scripts.GameLogic.Entities
{
    using RFL.Scripts.GlobalServices.Repository.DataContainers.Primitives;

    public interface IEntity
    {
        public SerializableGuid Id { get; }
    }
}