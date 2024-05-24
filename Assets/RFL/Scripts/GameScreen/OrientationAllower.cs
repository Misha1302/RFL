namespace RFL.Scripts.GameScreen
{
    using UnityEngine;

    public static class OrientationAllower
    {
        public static void AllowOrientation(AutoOrientation orientation)
        {
            Screen.autorotateToLandscapeLeft = orientation.HasFlagFast(AutoOrientation.LandscapeLeft);
            Screen.autorotateToLandscapeLeft = orientation.HasFlagFast(AutoOrientation.LandscapeRight);
            Screen.autorotateToPortrait = orientation.HasFlagFast(AutoOrientation.PortraitUp);
            Screen.autorotateToPortraitUpsideDown = orientation.HasFlagFast(AutoOrientation.PortraitDown);
            Screen.orientation = ScreenOrientation.AutoRotation;
        }
    }
}