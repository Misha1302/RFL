namespace RFL.Scripts.GlobalServices.Input.Services
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Input.Axis;
    using RFL.Scripts.GlobalServices.Repository;

    public abstract class InputServiceBase : MonoBeh, IInputService
    {
        public Axis2D Input { get; private set; }
        public bool Jump { get; protected set; }


        protected override void OnCreated()
        {
            Input = new Axis2D(Di.Get<RepositoryService>().GameData.InputSpeed);
        }

        protected static float CalcDir(bool neg, bool pos)
        {
            float dir = 0;
            if (pos) dir++;
            if (neg) dir--;
            return dir;
        }
    }
}