namespace RFL.Scripts.EditorHelpers
{
    using RFL.Scripts.GameManager;
    using UnityEngine;

    public class PauseSetter : MonoBehaviour
    {
        [SerializeField] private bool changeToPause;
        [SerializeField] private bool changeToUnPause;

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (changeToPause) Services.PauseService.Pause = true;
                if (changeToUnPause) Services.PauseService.Pause = false;
            }

            changeToPause = changeToUnPause = false;
        }
    }
}