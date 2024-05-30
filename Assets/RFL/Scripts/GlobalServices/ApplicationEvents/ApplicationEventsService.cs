namespace RFL.Scripts.GlobalServices.ApplicationEvents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class ApplicationEventsService : MonoBeh, IService
    {
        private readonly Dictionary<int, Action> _onAppQuit = new();

        private void OnDestroy()
        {
            _onAppQuit.OrderBy(x => x.Key).ForAll(x => x.Value.Invoke());
        }

        public void SubscribeOnAppQuit(Action action, int priority = 0)
        {
            _onAppQuit.TryAdd(priority, action);
            _onAppQuit[priority] -= action;
            _onAppQuit[priority] += action;
        }
    }
}