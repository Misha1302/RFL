namespace RFL.Scripts.EditorHelpers
{
    using UnityEngine;

    public class TimeSetter : MonoBehaviour
    {
        [Range(0.1f, 2f)] [SerializeField] private float scale;

        private void OnValidate()
        {
            Time.timeScale = scale;
        }
    }
}