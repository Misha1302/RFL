namespace RFL.Scripts.GlobalServices.Input.Services
{
    using RFL.Scripts.GlobalServices.Input.UI;
    using UnityEngine;

    public class MobileInputService : InputServiceBase
    {
        private MobileInputCanvas _canvas;

        protected override void Tick()
        {
            Input.X.HandleDirection(CalcXDir());
            Input.Y.HandleDirection(CalcYDir());

            Jump = _canvas.Jump.WasPressed;
        }

        private float CalcXDir() => CalcDir(_canvas.Left.WasPressed, _canvas.Right.WasPressed);

        private float CalcYDir() => CalcDir(_canvas.Down.WasPressed, _canvas.Up.WasPressed);

        protected override void OnStart()
        {
            var prefab = Resources.Load<MobileInputCanvas>("UI/CanvasMobileController");
            _canvas = Instantiate(prefab);
        }
    }
}