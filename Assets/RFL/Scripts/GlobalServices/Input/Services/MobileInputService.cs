namespace RFL.Scripts.GlobalServices.Input.Services
{
    using RFL.Scripts.GlobalServices.Input.UI;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class MobileInputService : InputServiceBase
    {
        private MobileInputCanvas _inputCanvas;

        protected override void TickAnyway()
        {
            Input.X.HandleDirection(CalcXDir());
            Input.Y.HandleDirection(CalcYDir());

            Jump = _inputCanvas.Jump.WasPressed;
        }

        private float CalcXDir() => CalcDir(_inputCanvas.Left.WasPressed, _inputCanvas.Right.WasPressed);

        private float CalcYDir() => CalcDir(_inputCanvas.Down.WasPressed, _inputCanvas.Up.WasPressed);

        protected override void OnStart()
        {
            base.OnStart();
            var mobileInputCanvas = Resources.Load<MobileInputCanvas>("UI/CanvasMobileController");
            _inputCanvas = Creator.Instantiate(mobileInputCanvas);
        }
    }
}