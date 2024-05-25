namespace RFL.Scripts
{
    using RFL.Scripts.GlobalServices;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using UnityEngine;

    public class FpsSetter : MonoBeh
    {
        protected override void OnStart()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = Services.RepositoryService.GameData.TargetFps;
        }
    }
}