namespace RFL.Scripts.GlobalServices.Fps
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    public class FpsSetterService : IService
    {
        public FpsSetterService()
        {
            SetTargetFps();
            Di.Get<RepositoryService>().GameData.targetFps.OnChanged += SetTargetFps;
        }

        private void SetTargetFps()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = Di.Get<RepositoryService>().GameData.targetFps.Value;
        }
    }
}