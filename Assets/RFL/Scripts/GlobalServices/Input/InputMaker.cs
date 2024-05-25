namespace RFL.Scripts.GlobalServices.Input
{
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class InputMaker
    {
        public static IInputService MakeInputService()
        {
            if (Input.touchSupported || RunMode.IsEditorSimulator())
                return Creator.Create<MobileInputService>();
            return Creator.Create<PcInputService>();
        }
    }
}