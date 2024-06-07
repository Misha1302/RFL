namespace RFL.Scripts.GlobalServices.Input
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class InputMaker
    {
        public static IInputService MakeInputService()
        {
            if (Input.touchSupported || RunMode.IsEditorSimulator())
                return Dc.Get<CreatorService>().Create<MobileInputService>();
            return Dc.Get<CreatorService>().Create<PcInputService>();
        }
    }
}