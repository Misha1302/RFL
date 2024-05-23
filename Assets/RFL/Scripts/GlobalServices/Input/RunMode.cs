using UnityEngine.Device;

namespace RFL.Scripts.GlobalServices.Input
{
    public static class RunMode
    {
        public enum ApplicationRunMode
        {
            Device,
            Editor,
            Simulator
        }

        public static ApplicationRunMode Current
        {
            get
            {
#if UNITY_EDITOR
                return Application.isEditor && !Application.isMobilePlatform
                    ? ApplicationRunMode.Editor
                    : ApplicationRunMode.Simulator;
#else
      return ApplicationRunMode.Device;
#endif
            }
        }
    }
}