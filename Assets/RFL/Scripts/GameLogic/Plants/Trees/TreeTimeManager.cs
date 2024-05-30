namespace RFL.Scripts.GameLogic.Plants.Trees
{
    using System;
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;

    public class TreeTimeManager : MonoBeh
    {
        private double _startTotalTime;

        public Action OnTimeToPhase1 = null!;
        public Action OnTimeToPhase2 = null!;
        public Action OnTimeToPhase3 = null!;

        private double TimeToPhase1 => _startTotalTime + FixedDeltaTime;
        private double TimeToPhase2 => _startTotalTime + 5d;
        private double TimeToPhase3 => _startTotalTime + 10d;

        protected override void FixedTick()
        {
            if (TotalTime.ApproxEq(TimeToPhase1)) OnTimeToPhase1?.Invoke();
            if (TotalTime.ApproxEq(TimeToPhase2)) OnTimeToPhase2?.Invoke();
            if (TotalTime.ApproxEq(TimeToPhase3)) OnTimeToPhase3?.Invoke();
        }

        public void Init(double startTotalTime)
        {
            _startTotalTime = startTotalTime;
        }
    }
}