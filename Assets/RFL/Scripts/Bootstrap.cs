namespace RFL.Scripts
{
    using System;
    using RFL.Scripts.DI;
    using RFL.Scripts.GameLogic;
    using RFL.Scripts.GlobalServices.Coroutines;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;
    using UnityEngine;

    public class Bootstrap : MonoBehaviour
    {
        private static readonly Lazy<Player> _player = new(FindObjectOfType<Player>);

        private void Awake()
        {
            Di.Instance.AddGlobalSingleton(_player.Value);
            Di.Instance.AddGlobalSingleton(Creator.Create<GlobalTime>());
            Di.Instance.AddGlobalSingleton(Creator.Create<CoroutinesManager>());
            Di.Instance.AddGlobalSingleton(Creator.Create<GameManager.GameManager>());
        }
    }
}