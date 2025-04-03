using System;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Windows
{
    public class WindowMenu : Window
    {
        public event Action OnClickPlay;
        public event Action OnClickSetting;

        public const string WindowName = "Menu"; 

        [SerializeField] private Button _buttonPlay;
        [SerializeField] private Button _buttonSetting;

        private void Awake()
        {
            Name = WindowName;
            _buttonPlay.onClick.AddListener(ClickButtonPlayHandler);
            _buttonPlay.onClick.AddListener(ClickButtonSettingHandler);
        }

        public void ClickButtonPlayHandler()
        {
            OnClickPlay?.Invoke();
        }

        public void ClickButtonSettingHandler()
        {
            OnClickSetting?.Invoke();
        }

        private void OnDestroy()
        {
            _buttonPlay.onClick.RemoveListener(ClickButtonPlayHandler);
            _buttonPlay.onClick.RemoveListener(ClickButtonSettingHandler);
        }
    }
}
