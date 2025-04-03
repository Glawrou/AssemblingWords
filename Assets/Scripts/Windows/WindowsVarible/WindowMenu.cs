using System;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Windows
{
    public class WindowMenu : Window
    {
        public event Action OnClickPlay;
        public event Action OnClickSetting;

        [SerializeField] private Button _buttonPlay;
        [SerializeField] private Button _buttonSetting;

        private void Awake()
        {
            _buttonPlay.onClick.AddListener(ClickButtonPlayHandler);
            _buttonSetting.onClick.AddListener(ClickButtonSettingHandler);
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
            _buttonSetting.onClick.RemoveListener(ClickButtonSettingHandler);
        }
    }
}
