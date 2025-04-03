using System;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Windows
{
    public class WindowSettings : Window
    {
        public event Action<bool> OnToggleSoundChanged;
        public event Action OnClickBack;

        [SerializeField] private Toggle _toggleSound;
        [SerializeField] private Button _buttonBack;

        private void Awake()
        {
            _toggleSound.onValueChanged.AddListener(ToggleValueChangeHandler);
            _buttonBack.onClick.AddListener(ButtonClickHandler);
        }

        public void SetSoundToggle(bool isSound)
        {
            _toggleSound.isOn = isSound;
        }

        private void ToggleValueChangeHandler(bool value)
        {
            OnToggleSoundChanged?.Invoke(value);
        }

        private void ButtonClickHandler()
        {
            OnClickBack?.Invoke();
        }

        private void OnDestroy()
        {
            _toggleSound.onValueChanged.RemoveListener(ToggleValueChangeHandler);
            _buttonBack.onClick.RemoveListener(ButtonClickHandler);
        }
    }
}
