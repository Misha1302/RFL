namespace RFL.Scripts
{
    using RFL.Scripts.GlobalServices.Input;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class InputService
    {
        public static IInputService MakeInput()
        {
            if (Input.touchSupported)
                return Creator.Create<MobileInputService>();
            return Creator.Create<PcInputService>();
        }
    }
}