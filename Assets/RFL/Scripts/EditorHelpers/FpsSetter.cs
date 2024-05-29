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
            _ = new RepositoryService
            {
                GameData =
                {
                    TargetFps = targetFps,
                    NeedToShowFps = needToShowFps
                }
            };
        }
    }
}