namespace RFL.Scripts.GameLogic.Plants.Trees
{
    using System;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.Helpers;

    public class TreeTimeManager : MonoBeh
    {
        private double _startTotalTime;

        public Action<TreePhaseType> OnTimeToPhase;


        public void Init(double startTotalTime)
        {
            _startTotalTime = startTotalTime;

            Creator.Create<TimeEvent>().Init(_startTotalTime).OnTimeCome +=
                () => OnTimeToPhase(TreePhaseType.Phase1);

            Creator.Create<TimeEvent>().Init(_startTotalTime + 5d).OnTimeCome +=
                () => OnTimeToPhase(TreePhaseType.Phase2);

            Creator.Create<TimeEvent>().Init(_startTotalTime + 10d).OnTimeCome +=
                () => OnTimeToPhase(TreePhaseType.Phase3);
        }
    }
}