namespace RFL.Scripts.EditorHelpers
{
    using UnityEngine;

    public class FramesSetter : MonoBehaviour
    {
        [Range(0, 300)] [SerializeField] private int framesCount = 300;

        private void OnValidate()
        {
            Application.targetFrameRate = framesCount;
        }
    }
}