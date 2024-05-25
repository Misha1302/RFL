namespace RFL.Scripts.GameLogic.Fps
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    public class FpsSetter : MonoBeh
    {
        protected override void OnStart()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = Di.Get<RepositoryService>().GameData.TargetFps;
        }
    }
}