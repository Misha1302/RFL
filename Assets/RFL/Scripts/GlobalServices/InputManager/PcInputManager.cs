namespace RFL.Scripts.GlobalServices.InputManager
{
    using RFL.Scripts.GameManager;
    using UnityEngine;

    public class PcInputManager : MonoBeh, IInputManager
    {
        public Vector2 Input { get; private set; }

        public override void Tick()
        {
            var input = Input;
            input.x = UnityEngine.Input.GetAxis("Horizontal");
            input.y = UnityEngine.Input.GetAxis("Vertical");
            Input = input;
        }
    }
}