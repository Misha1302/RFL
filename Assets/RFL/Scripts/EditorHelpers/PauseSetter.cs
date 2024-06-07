namespace RFL.Scripts.EditorHelpers
{
    using RFL.Scripts.DI;
    using RFL.Scripts.GlobalServices.Pause;
    using UnityEngine;

    public class PauseSetter : MonoBehaviour
    {
#if UNITY_EDITOR
        [SerializeField] private bool changeToPause;
        [SerializeField] private bool changeToUnPause;

        private void OnValidate()
        {
            if (Application.isPlaying)
            {
                if (changeToPause) Dc.Get<PauseService>().IsPaused = true;
                if (changeToUnPause) Dc.Get<PauseService>().IsPaused = false;
            }

            changeToPause = changeToUnPause = false;
        }
#endif
    }
}