namespace RFL.Scripts.GlobalServices.Input.Services
{
    using UnityEngine;

    public class PcInputService : InputServiceBase
    {
        protected override void Tick()
        {
            Input.X.HandleDirection(UnityEngine.Input.GetAxisRaw("Horizontal"));
            Input.Y.HandleDirection(UnityEngine.Input.GetAxisRaw("Vertical"));

            Jump = UnityEngine.Input.GetKey(KeyCode.Space);
        }
    }
}