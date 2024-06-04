namespace RFL.Scripts.GlobalServices.Fps
{
    using RFL.Scripts.DI;
    using RFL.Scripts.Extensions.Math.Numbers;
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
            const int maxFramesCount = 10_000;

            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate =
                Di.Get<RepositoryService>().GameData.targetFps.Value.ThisOrIf(x => x < 0, maxFramesCount);
        }
    }
}