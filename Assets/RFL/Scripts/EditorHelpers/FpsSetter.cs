namespace RFL.Scripts.EditorHelpers
{
    using UnityEngine;

    // TODO: make service FpsService and RepositoryService
    public class FpsSetter : MonoBehaviour
    {
        [Range(-1, 100)] [SerializeField] private int framesCount = -1;

        private void Start()
        {
            SetFrames();
        }

        private void OnValidate()
        {
            SetFrames();
        }

        private void SetFrames()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = framesCount;
        }
    }
}