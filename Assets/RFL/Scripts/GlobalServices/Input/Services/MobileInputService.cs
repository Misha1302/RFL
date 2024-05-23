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

            Input.X.HandleDirection(CalcXDir());
            Input.X.HandleDirection(CalcYDir());
        }

        private float CalcYDir() => CalcDir(_canvas.Left.WasPressed, _canvas.Right.WasPressed);

        private float CalcXDir() => CalcDir(_canvas.Down.WasPressed, _canvas.Up.WasPressed);


        private static float CalcDir(bool neg, bool pos)
        {
            float dir = 0;
            if (pos) dir++;
            if (neg) dir--;
            return dir;
        }

        protected override void OnStart()
        {
            var prefab = Resources.Load<MobileInputCanvas>("UI/CanvasMobileController");
            _canvas = Instantiate(prefab);
        }
    }
}