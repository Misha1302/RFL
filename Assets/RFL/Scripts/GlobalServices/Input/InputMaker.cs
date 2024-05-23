namespace RFL.Scripts.GlobalServices.Input
{
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class InputMaker
    {
        public static IInputService MakeInput()
        {
            if (Input.touchSupported || RunMode.Current == RunMode.ApplicationRunMode.Simulator)
                return Creator.Create<MobileInputService>();
            return Creator.Create<PcInputService>();
        }
    }
}