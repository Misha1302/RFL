namespace RFL.Scripts.GlobalServices.InputManager
{
    using UnityEngine;

    public interface IInputManager
    {
        public Vector2 Input { get; }
        public bool Jump { get; }
    }
}