﻿namespace RFL.Scripts.EditorHelpers
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Pause;
    using UnityEngine;

    public class PauseSetter : MonoBehaviour
    {
        [SerializeField] private bool changeToPause;
        [SerializeField] private bool changeToUnPause;

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (changeToPause) Di.Get<PauseService>().IsPaused = true;
                if (changeToUnPause) Di.Get<PauseService>().IsPaused = false;
            }

            changeToPause = changeToUnPause = false;
        }
    }
}