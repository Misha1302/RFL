namespace RFL.Scripts.GameLogic.Entities.Plants.Trees
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Time;
    using RFL.Scripts.Helpers;

    public class TreeTimeManager : MonoBeh
    {
        private readonly double[] _phaseWaitTimes = { 0d, 5d, 10d };

        [Inject] private CreatorService _creatorService;
        private double _startTotalTime;

        public Action<TreePhaseType> OnTimeToPhase;

        public void Init(double startTotalTime)
        {
            _startTotalTime = startTotalTime;

            _creatorService.Create<TimeEvent>().Init(_startTotalTime + _phaseWaitTimes[0])
                .OnTimeCome += () => OnTimeToPhase(TreePhaseType.Phase1);

            _creatorService.Create<TimeEvent>().Init(_startTotalTime + _phaseWaitTimes[1])
                .OnTimeCome += () => OnTimeToPhase(TreePhaseType.Phase2);

            _creatorService.Create<TimeEvent>().Init(_startTotalTime + _phaseWaitTimes[2])
                .OnTimeCome += () => OnTimeToPhase(TreePhaseType.Phase3);
        }
    }
}