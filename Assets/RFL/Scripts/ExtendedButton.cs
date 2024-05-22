namespace RFL.Scripts
{
    using UnityEngine.UI;

    public class ExtendedButton : Button
    {
        public bool WasPressed => IsPressed();
    }
}