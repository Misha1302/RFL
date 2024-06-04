namespace RFL.Scripts.EditorHelpers
{
    using UnityEngine;

    public class TimeSetter : MonoBehaviour
    {
        [Range(0.002f, 2f)] [SerializeField] private float scale = 1;

#if UNITY_EDITOR
        private void OnValidate()
        {
            Time.timeScale = scale;
        }
#endif
    }
}