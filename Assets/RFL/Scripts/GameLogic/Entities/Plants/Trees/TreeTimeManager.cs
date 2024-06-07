namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using System;
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;

    public class TreeTimeManager : MonoBeh
    {
        private double _startTotalTime;

        public Action<TreePhaseType> OnTimeToPhase;


        public void Init(double startTotalTime)
        {
            _startTotalTime = startTotalTime;

            Dc.Get<CreatorService>().Create<TimeEvent>().Init(_startTotalTime).OnTimeCome +=
                () => OnTimeToPhase(TreePhaseType.Phase1);

            Dc.Get<CreatorService>().Create<TimeEvent>().Init(_startTotalTime + 5d).OnTimeCome +=
                () => OnTimeToPhase(TreePhaseType.Phase2);

            Dc.Get<CreatorService>().Create<TimeEvent>().Init(_startTotalTime + 10d).OnTimeCome +=
                () => OnTimeToPhase(TreePhaseType.Phase3);
        }
    }
}