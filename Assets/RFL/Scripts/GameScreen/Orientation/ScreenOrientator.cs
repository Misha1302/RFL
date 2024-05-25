namespace RFL.Scripts.GameScreen.Orientation
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class ScreenOrientator : MonoBeh
    {
        protected override void OnStart()
        {
            OrientationAllower.AllowOrientation(AutoOrientation.Landscape, AutoOrientation.LandscapeRight);
        }
    }
}