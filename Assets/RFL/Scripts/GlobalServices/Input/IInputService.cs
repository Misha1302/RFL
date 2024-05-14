namespace RFL.Scripts.GlobalServices.Input
{
    using UnityEngine;

    public interface IInputService
    {
        public Vector2 Input { get; }
        public bool Jump { get; }
    }
}