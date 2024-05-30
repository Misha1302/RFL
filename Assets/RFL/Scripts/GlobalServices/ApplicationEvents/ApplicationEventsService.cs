namespace RFL.Scripts.GlobalServices.ApplicationEvents
{
    using System;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class ApplicationEventsService : MonoBeh, IService
    {
        public Action OnAppQuit = null!;

        private void OnDestroy()
        {
            OnAppQuit?.Invoke();
        }
    }
}