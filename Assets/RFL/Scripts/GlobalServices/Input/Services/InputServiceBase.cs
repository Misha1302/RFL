namespace RFL.Scripts.GlobalServices.Input.Services
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Axis;
    using Services = RFL.Scripts.GlobalServices.Services;

    public abstract class InputServiceBase : MonoBeh, IInputService
    {
        public Axis2D Input { get; } = new(Services.RepositoryService.GameData.InputSpeed);
        public bool Jump { get; protected set; }


        protected static float CalcDir(bool neg, bool pos)
        {
            float dir = 0;
            if (pos) dir++;
            if (neg) dir--;
            return dir;
        }
    }
}