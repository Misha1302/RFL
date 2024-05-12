namespace RFL.Scripts.GameManager
{
    using System.Collections.Generic;
    using RFL.Scripts.Extensions;
    using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public bool pause;

        private readonly List<MonoBeh> _monoBehs = new();

        private void Start()
        {
            if (!pause)
                _monoBehs.ForAll(x => x.OnStart());
        }

        private void Update()
        {
            if (!pause)
                _monoBehs.ForAll(x => x.Tick());
        }

        private void FixedUpdate()
        {
            if (!pause)
                _monoBehs.ForAll(x => x.FixedTick());
        }

        private void LateUpdate()
        {
            if (!pause)
                _monoBehs.ForAll(x => x.LateTick());
        }


        public void AddMonoBeh(MonoBeh monoBeh) => _monoBehs.Add(monoBeh);

        public void RemoveMonoBeh(MonoBeh monoBeh) => _monoBehs.Remove(monoBeh);
    }
}