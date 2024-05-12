namespace RFL.Scripts.GameManager
{
    using System.Collections.Generic;
    using RFL.Scripts.Extensions;
    using UnityEngine;

    public class GameService : MonoBehaviour
    {
        private readonly List<MonoBeh> _monoBehs = new();

        private void Start() => _monoBehs.ForAll(x => x.OnStart());

        private void Update() => _monoBehs.ForAll(x => x.Tick());

        private void FixedUpdate() => _monoBehs.ForAll(x => x.FixedTick());

        private void LateUpdate() => _monoBehs.ForAll(x => x.LateTick());


        private void Awake() => Services.PauseService.OnPausedChanged += OnPausedChanged;


        private void OnPausedChanged(bool isPaused) => enabled = !isPaused;


        public void AddMonoBeh(MonoBeh monoBeh) => _monoBehs.Add(monoBeh);

        public void RemoveMonoBeh(MonoBeh monoBeh) => _monoBehs.Remove(monoBeh);
    }
}