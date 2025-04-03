using System;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Windows
{
    public class WindowMenu : Window
    {
        public event Action OnClickPlay;
        public event Action OnClickSetting;

        public const string WindowMenuName = "Menu"; 

        [SerializeField] private Button _buttonPlay;
        [SerializeField] private Button _buttonSetting;

        private void Awake()
        {
            Name = WindowMenuName;
            _buttonPlay.onClick.AddListener(ClickButtonPlayHandler);
            _buttonPlay.onClick.AddListener(ClickButtonSettingHandler);
        }

        public override void Open()
        {
            SetActive(true);
        }

        public override void Close()
        {
            SetActive(false);
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
