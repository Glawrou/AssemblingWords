using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Windows
{
    public class WindowsManager : MonoBehaviour
    {
        public event Action OnClickPlay;

        [SerializeField] private Image _background;

        [Header("Windows")]
        [SerializeField] private WindowMenu _windowMenu;
        [SerializeField] private WindowSettings _windowSettings;
        [SerializeField] private WindowWin _windowWin;

        private Window[] _windows;

        private void Awake()
        {
            AddListeners();
            
        }

        private void Start()
        {
            CloseAll();
            Open(_windowMenu);
        }

        public void CloseAll()
        {
            SetActiveBackground(false);
            GetWindows().ToList().ForEach(w => w.Close());
        }

        private void Open(Window window)
        {
            CloseAll();
            SetActiveBackground(true);
            window.Open();
        }

        public void OpenWindowSettings() => Open(_windowSettings);

        public void OpenWindowWin(string[] words)
        {
            Open(_windowWin);
            _windowWin.FillResult(words);
        }

        public void OpenWindowMenu() => Open(_windowMenu);

        private void ClickPlayHandler()
        {
            CloseAll();
            OnClickPlay?.Invoke();
        }

        private void SetActiveBackground(bool isActive)
        {
            _background.gameObject.SetActive(isActive);
        }

        private Window[] GetWindows()
        {
            if (_windows == null)
            {
                _windows = new Window[]
                {
                    _windowMenu,
                    _windowSettings,
                    _windowWin
                };
            }

            return _windows;
        }

        private void AddListeners()
        {
            _windowMenu.OnClickSetting += OpenWindowSettings;
            _windowWin.OnClickMainMenu += OpenWindowMenu;
            _windowSettings.OnClickBack += OpenWindowMenu;
            _windowMenu.OnClickPlay += ClickPlayHandler;
            _windowWin.OnClickNextLevel += ClickPlayHandler;
        }

        private void RemoveListeners()
        {
            _windowMenu.OnClickSetting -= OpenWindowSettings;
            _windowWin.OnClickMainMenu -= OpenWindowMenu;
            _windowSettings.OnClickBack -= OpenWindowMenu;
            _windowMenu.OnClickPlay -= ClickPlayHandler;
            _windowWin.OnClickNextLevel -= ClickPlayHandler;
        }

        private void OnDestroy()
        {
            RemoveListeners();
        }
    }
}
