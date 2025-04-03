using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Windows
{
    public class WindowsManager : MonoBehaviour
    {
        [SerializeField] private Window[] _windows;
        [SerializeField] private Image _background;

        private Window _currentWindow;

        private void Awake()
        {
            _windows.ToList().ForEach(window => window.Close());
        }

        public void SetActiveBackground(bool isActive)
        {
            _background.gameObject.SetActive(isActive);
        }

        public void Open(string name)
        {
            if (!_windows.Any(w => w.Name.Equals(name)))
            {
                Debug.LogWarning("naa >> AssemblingWords >> Windows >> WindowsManager >> Open() >> The window was not found");
                return;
            }

            CloseAll();
            SetActiveBackground(true);
            _currentWindow = _windows.FirstOrDefault(w => w.Name.Equals(name));
            _currentWindow.Open();
        }

        public void CloseAll()
        {
            SetActiveBackground(false);
            _windows.ToList().ForEach(w => w.Close());
            _currentWindow = null;
        }
    }
}
