namespace RFL.Scripts.GlobalServices.InputManager
{
    using RFL.Scripts.GameManager;
    using UnityEngine;

    public class PcInputService : MonoBeh, IInputService
    {
        public Vector2 Input { get; private set; }
        public bool Jump { get; private set; }

        public override void Tick()
        {
            var input = Input;
            input.x = UnityEngine.Input.GetAxis("Horizontal");
            input.y = UnityEngine.Input.GetAxis("Vertical");
            Input = input;

            Jump = UnityEngine.Input.GetKey(KeyCode.Space);
        }
    }
}