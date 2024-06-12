namespace RFL.Scripts.GlobalServices.Scenes
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    /// <summary>
    ///     Since Destroy works in next frame, we need to mark object as DestroyingTag, so we don't continue to use it
    /// </summary>
    public class DestroyingTag : MonoBeh { }
}