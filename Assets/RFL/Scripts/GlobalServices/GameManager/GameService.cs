﻿namespace RFL.Scripts.GlobalServices.GameManager
{
    using System.Collections.Generic;
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.Pause;
    using UnityEngine;

    public class GameService : MonoBehaviour, IService
    {
        private readonly List<MonoBeh.MonoBeh> _monoBehs = new();

        private bool _isEnabled;


        private void Awake() => Di.Get<PauseService>().OnPausedChanged += OnPausedChanged;

        private void Update()
        {
            Di.Get<NextMomentExecutorService>().CustomTick();
            if (!_isEnabled) return;
            _monoBehs.ForAll(x => x.PubTick());
        }

        private void FixedUpdate()
        {
            Di.Get<NextMomentExecutorService>().CustomTick();
            if (!_isEnabled) return;
            _monoBehs.ForAll(x => x.PubFixedTick());
        }

        private void LateUpdate()
        {
            if (!_isEnabled) return;
            _monoBehs.ForAll(x => x.PubLateTick());
        }


        private void OnPausedChanged(bool isPaused) => _isEnabled = !isPaused;


        public void AddMonoBeh(MonoBeh.MonoBeh monoBeh)
        {
            _monoBehs.Add(monoBeh);
            Di.Get<NextMomentExecutorService>().ExecuteInNextMoment(monoBeh.PubOnStart);
        }

        public void RemoveMonoBeh(MonoBeh.MonoBeh monoBeh)
        {
            _monoBehs.Remove(monoBeh);
        }
    }
}