namespace RFL.Scripts
{
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class UiInitializer : MonoBeh
    {
        protected override void OnStart()
        {
            Creator.Instantiate(Resources.Load("UI/EventSystem"));
        }
    }
}