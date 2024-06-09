namespace RFL.Scripts.EditorHelpers
{
    using System;
    using RFL.Scripts.Attributes;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using RFL.Scripts.GlobalServices.Pause;
    using UnityEngine;

    public class PauseSetter : MonoBeh
    {
#if UNITY_EDITOR
        [SerializeField] private bool changeToPause;
        [SerializeField] private bool changeToUnPause;

        [Inject] private Lazy<PauseService> _pauseService;

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (changeToPause) _pauseService.Value.IsPaused = true;
                if (changeToUnPause) _pauseService.Value.IsPaused = false;
            }

            changeToPause = changeToUnPause = false;
        }
#endif
    }
}