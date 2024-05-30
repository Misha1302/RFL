namespace RFL.Scripts.GlobalServices.ApplicationEvents
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class ApplicationEventsService : MonoBeh, IService
    {
        private readonly Dictionary<int, Action> _onAppQuit = new();

        private void OnApplicationQuit()
        {
            _onAppQuit.OrderBy(x => x.Key).ForAll(x => x.Value.Invoke());
            FindObjectsByType<MonoBeh>(FindObjectsInactive.Include, FindObjectsSortMode.None)
                .ForAll(x => x.isEnabled = false);
        }

        public void SubscribeOnAppQuit(Action action, int priority = 0)
        {
            _onAppQuit.TryAdd(priority, action);
            _onAppQuit[priority] -= action;
            _onAppQuit[priority] += action;
        }
    }
}