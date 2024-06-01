#if UNITY_EDITOR

namespace RFL.Scripts.EditorHelpers
{
    using RFL.Scripts.GlobalServices.Repository;
    using UnityEngine;

    public class FpsSetter : MonoBehaviour
    {
        [Range(-1, 60)] [SerializeField] private int targetFps = -1;
        [SerializeField] private bool needToShowFps = true;

        private void OnValidate()
        {
            if (Application.isPlaying) return;

            var repository = new RepositoryService();
            repository.GameData.targetFps.Value = targetFps;
            repository.GameData.needToShowFps.Value = needToShowFps;
        }
    }
}

#endif