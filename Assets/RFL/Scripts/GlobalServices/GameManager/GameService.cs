namespace RFL.Scripts.GlobalServices.GameManager
{
    using System;
    using System.Collections.Generic;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.Pause;
    using RFL.Scripts.Singletons;
    using UnityEngine;

    public class GameService : MonoBehaviour, IService
    {
        private readonly List<MonoBeh.MonoBeh> _monoBehs = new();

        private bool _isEnabled = true;

        [Inject] private Lazy<NextMomentExecutorService> _nextMomentExecutorService;
        [Inject] private Lazy<PauseService> _pauseService;


        private void Awake()
        {
            GameSingletons.DependencyInjector.Inject(this);
            _pauseService.Value.OnPausedChanged += OnPausedChanged;
        }

        private void Update()
        {
            _nextMomentExecutorService.Value.CustomTick();
            if (!_isEnabled) return;
            _monoBehs.ForAll(x => x.PubTick());
        }

        private void FixedUpdate()
        {
            _nextMomentExecutorService.Value.CustomTick();
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
            _nextMomentExecutorService.Value.ExecuteInNextMoment(monoBeh.PubOnStart);
        }

        public void RemoveMonoBeh(MonoBeh.MonoBeh monoBeh)
        {
            _monoBehs.Remove(monoBeh);
        }
    }
}