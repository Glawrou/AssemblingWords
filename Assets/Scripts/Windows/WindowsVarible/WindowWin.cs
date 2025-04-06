using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace naa.AssemblingWords.Windows
{
    public class WindowWin : Window
    {
        public event Action OnClickMainMenu;
        public event Action OnClickNextLevel;

        [SerializeField] private Button _buttonMainMenu;
        [SerializeField] private Button _buttonNextLevel;
        [SerializeField] private TextMeshProUGUI _textResult;

        private void Awake()
        {
            _buttonMainMenu.onClick.AddListener(ClickMainMenuHandler);
            _buttonNextLevel.onClick.AddListener(ClickNextLevel);
        }

        public void FillResult(string[] words)
        {
            _textResult.text = string.Empty;
            words.ToList().ForEach(w => _textResult.text += w.ToUpper() + '\n');
        }

        private void ClickMainMenuHandler()
        {
            OnClickMainMenu?.Invoke();
        }

        private void ClickNextLevel()
        {
            OnClickNextLevel?.Invoke();
        }

        private void OnDestroy()
        {
            _buttonMainMenu.onClick.RemoveListener(ClickMainMenuHandler);
            _buttonNextLevel.onClick.RemoveListener(ClickNextLevel);
        }
    }
}
