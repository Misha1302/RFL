namespace RFL.Scripts.GlobalServices.Input.Services
{
    using System;
    using RFL.Scripts.GlobalServices.Input.Axis;

    public interface IInputService : IService
    {
        public Axis2D Input { get; }
        public bool Jump { get; }
        public Action OnPause { get; set; }
    }
}