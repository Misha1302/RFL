namespace RFL.Scripts.GlobalServices.Input.Services
{
    using RFL.Scripts.GlobalServices.Input.Axis;

    public interface IInputService
    {
        public Axis2D Input { get; }
        public bool Jump { get; }
    }
}