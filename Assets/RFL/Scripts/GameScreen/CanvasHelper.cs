namespace RFL.Scripts.GameScreen
{
    using RFL.Scripts.Extensions;
    using RFL.Scripts.GlobalServices.GameManager.MonoBeh;
    using Unity.VisualScripting;
    using UnityEngine;

    /// <summary>
    ///     <a href="https://forum.unity.com/threads/canvashelper-resizes-a-recttransform-to-iphone-xs-safe-area.521107/">
    ///         code taken from here
    ///     </a>
    /// </summary>
    [RequireComponent(typeof(Canvas))]
    public class CanvasHelper : MonoBeh
    {
        private static bool _screenChangeVarsInitialized;
        private static ScreenOrientation _lastOrientation;
        private static Vector2 _lastResolution;
        private static Rect _lastSafeArea;

        private Canvas _canvas;
        private RectTransform _safeAreaTransform;

        private void OnValidate()
        {
            var safeArea = GetSafeAreaObject();
            SetSafeAreaCharacteristics(safeArea);
        }

        private void SetSafeAreaCharacteristics(SafeAreaTag safeArea)
        {
            safeArea.name = "Safe area";
            safeArea.transform.SetParent(transform);

            if (!safeArea.HasComponent<RectTransform>())
                safeArea.AddComponent<RectTransform>();

            var rectTransform = safeArea.GetComponent<RectTransform>();
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.anchorMin = new Vector2(0, 0);
            rectTransform.anchorMax = new Vector2(1, 1);
            rectTransform.pivot = new Vector2(0.5f, 0.5f);
        }

        private SafeAreaTag GetSafeAreaObject()
        {
            var safeArea = transform.GetComponentInChildren<SafeAreaTag>(true);
            if (!safeArea)
                safeArea = new GameObject().AddComponent<SafeAreaTag>();
            return safeArea;
        }

        protected override void Tick()
        {
            if (Application.isMobilePlatform && Screen.orientation != _lastOrientation)
                OnOrientationChanged();

            if (Screen.safeArea != _lastSafeArea)
                ApplySafeArea();

            if (Mathf.Approximately(Screen.width, _lastResolution.x) ||
                Mathf.Approximately(Screen.height, _lastResolution.y))
                OnResolutionChanged();
        }

        protected override void OnStart()
        {
            _safeAreaTransform = GetSafeAreaObject().GetComponent<RectTransform>();
            _canvas = GetComponent<Canvas>();

            SetStaticsIfNeed();

            ApplySafeArea();
        }

        private static void SetStaticsIfNeed()
        {
            if (_screenChangeVarsInitialized) return;

            _lastOrientation = Screen.orientation;
            _lastResolution.x = Screen.width;
            _lastResolution.y = Screen.height;
            _lastSafeArea = Screen.safeArea;

            _screenChangeVarsInitialized = true;
        }

        private void ApplySafeArea()
        {
            if (_safeAreaTransform == null)
                return;

            GetAnchors(out var anchorMin, out var anchorMax);

            _safeAreaTransform.anchorMin = anchorMin;
            _safeAreaTransform.anchorMax = anchorMax;
        }

        private void GetAnchors(out Vector2 anchorMin, out Vector2 anchorMax)
        {
            var safeArea = Screen.safeArea;
            anchorMin = GetAnchor(safeArea.position);
            anchorMax = GetAnchor(safeArea.position + safeArea.size);
        }

        private Vector2 GetAnchor(Vector2 startAnchor)
        {
            startAnchor.x /= _canvas.pixelRect.width;
            startAnchor.y /= _canvas.pixelRect.height;
            return startAnchor;
        }

        private static void OnOrientationChanged()
        {
            _lastOrientation = Screen.orientation;
            _lastResolution.x = Screen.width;
            _lastResolution.y = Screen.height;
        }

        private static void OnResolutionChanged()
        {
            _lastResolution.x = Screen.width;
            _lastResolution.y = Screen.height;
        }
    }
}