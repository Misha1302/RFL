namespace RFL.Scripts.GlobalServices.Input.Services
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Axis;
    using RFL.Scripts.GlobalServices.Input.UI;
    using UnityEngine;

    public class MobileInputService : MonoBeh, IInputService
    {
        private MobileInputCanvas _canvas;

        public Axis2D Input { get; } = new(IInputService.InputSpeed);
        public bool Jump { get; private set; }

        protected override void Tick()
        {
            Jump = _canvas.Jump.WasPressed;

            if (_canvas.Left.WasPressed) Input.X.Decrease();
            else if (_canvas.Right.WasPressed) Input.X.Increase();
            else Input.X.Zero();

            if (_canvas.Up.WasPressed) Input.Y.Increase();
            else if (_canvas.Down.WasPressed) Input.Y.Decrease();
            else Input.Y.Zero();
        }

        protected override void OnStart()
        {
            var prefab = Resources.Load<MobileInputCanvas>("UI/CanvasMobileController");
            _canvas = Instantiate(prefab);
        }
    }
}