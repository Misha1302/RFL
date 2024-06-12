namespace RFL.Scripts.EditorHelpers
{
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using UnityEngine;

    public class EditorPauseSetter : MonoBeh
    {
#if UNITY_EDITOR
        [SerializeField] private bool changeToPause;
        [SerializeField] private bool changeToUnPause;

        [Inject] private PauseService _pauseService;

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (changeToPause) _pauseService.IsPaused = true;
                if (changeToUnPause) _pauseService.IsPaused = false;
            }

            changeToPause = changeToUnPause = false;
        }
#endif
    }
}