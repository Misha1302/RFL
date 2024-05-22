namespace RFL.Scripts.GlobalServices.Input.Services
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Axis;
    using UnityEngine;

    public class PcInputService : MonoBeh, IInputService
    {
        public Axis2D Input { get; } = new(IInputService.InputSpeed);
        public bool Jump { get; private set; }

        public override void Tick()
        {
            var hor = UnityEngine.Input.GetAxisRaw("Horizontal");
            var ver = UnityEngine.Input.GetAxisRaw("Vertical");

            if (hor > 0) Input.X.Increase();
            else if (hor < 0) Input.X.Decrease();
            else Input.X.Zero();

            if (ver > 0) Input.Y.Increase();
            else if (ver < 0) Input.Y.Decrease();
            else Input.Y.Zero();

            Jump = UnityEngine.Input.GetKey(KeyCode.Space);
        }
    }
}