namespace RFL.Scripts.EditorHelpers
{
    using UnityEngine;

    public class FramesSetter : MonoBehaviour
    {
        [Range(-1, 100)] [SerializeField] private int framesCount = -1;

        private void OnValidate()
        {
            Application.targetFrameRate = framesCount;
        }
    }
}