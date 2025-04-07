using UnityEngine;

namespace naa.AssemblingWords.System
{
    [RequireComponent(typeof(RectTransform))]
    public class SafeAreaScaler : MonoBehaviour
    {
        private RectTransform _rectTransform;

        private void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            ApplySafeArea();
        }

        private void ApplySafeArea()
        {
            Rect safeArea = Screen.safeArea;
            Vector2 min = safeArea.position;
            Vector2 max = safeArea.position + safeArea.size;
            min.x /= Screen.width;
            min.y /= Screen.height;
            max.x /= Screen.width;
            max.y /= Screen.height;
            _rectTransform.anchorMin = min;
            _rectTransform.anchorMax = max;
        }
    }
}
