namespace RFL.Scripts.GlobalServices.GameManager
{
    using System.Collections.Generic;
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.Pause;
    using UnityEngine;

    public class GameService : MonoBehaviour, IService
    {
        private readonly List<MonoBeh.MonoBeh> _monoBehs = new();


        private void Awake() => Di.Get<PauseService>().OnPausedChanged += OnPausedChanged;

        private void Start() => _monoBehs.ForAll(x => x.PubOnStart());

        private void Update() => _monoBehs.ForAll(x => x.PubTick());

        private void FixedUpdate() => _monoBehs.ForAll(x => x.PubFixedTick());

        private void LateUpdate() => _monoBehs.ForAll(x => x.PubLateTick());


        private void OnPausedChanged(bool isPaused) => enabled = !isPaused;


        public void AddMonoBeh(MonoBeh.MonoBeh monoBeh)
        {
            _monoBehs.Add(monoBeh);
        }

        public void RemoveMonoBeh(MonoBeh.MonoBeh monoBeh)
        {
            _monoBehs.Remove(monoBeh);
        }
    }
}