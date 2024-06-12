namespace RFL.Scripts.GameScreen.Orientation
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GameLogic.Scenes;

    public class ScreenOrientationInitializer
    {
        [SceneInitializer(typeof(AnyScene), initializationType: InitializationType.Once)]
        public static void Initialize()
        {
            OrientationAllower.AllowOrientation(AutoOrientation.Landscape, AutoOrientation.LandscapeRight);
        }
    }
}