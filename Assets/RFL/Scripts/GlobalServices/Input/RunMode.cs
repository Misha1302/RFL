namespace RFL.Scripts.GlobalServices.Input
{
#if UNITY_EDITOR
    using UnityEngine;
    using SystemInfo = UnityEngine.Device.SystemInfo;
#endif


    public static class RunMode
    {
        public static bool IsEditorSimulator()
        {
#if UNITY_EDITOR
            return SystemInfo.deviceType != DeviceType.Desktop;
#else
            return false;
#endif
        }
    }
}