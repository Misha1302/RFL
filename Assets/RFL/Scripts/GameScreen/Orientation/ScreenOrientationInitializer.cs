namespace RFL.Scripts.GameScreen.Orientation
{
    using RFL.Scripts.Attributes;

    public class ScreenOrientationInitializer
    {
        [InitializerMethod]
        public static void Initialize()
        {
            OrientationAllower.AllowOrientation(AutoOrientation.Landscape, AutoOrientation.LandscapeRight);
        }
    }
}