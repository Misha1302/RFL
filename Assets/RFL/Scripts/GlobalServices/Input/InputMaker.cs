namespace RFL.Scripts.GlobalServices.Input
{
    using RFL.Scripts.GlobalServices.Input.Services;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public static class InputMaker
    {
        public static IInputService MakeInputService(CreatorService creatorService)
        {
            if (Input.touchSupported || RunMode.IsEditorSimulator())
                return creatorService.Create<MobileInputService>();
            return creatorService.Create<PcInputService>();
        }
    }
}