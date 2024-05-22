namespace RFL.Scripts.GlobalServices.Input
{
    public interface IInputService
    {
        public Axis2D Input { get; }
        public bool Jump { get; }

        protected static float InputSpeed => 1f / 0.4f;
    }
}