namespace RFL.Scripts.GameScreen
{
    public static class AutoRotateExtensions
    {
        public static bool HasFlagFast(this AutoOrientation value, AutoOrientation flag) => 
            (value & flag) != 0;
    }
}