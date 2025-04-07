using naa.AssemblingWords.Data;
using naa.AssemblingWords.Windows;
using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Game
{
    public class GameController : MonoBehaviour
    {   
        [Inject] private LevelController _levelController;
        [Inject] private WindowsManager _windowsManager;
        [Inject] private LevelStorage _levelStorage;

        private int _levelCount = 0;

        private void Awake()
        {
            _windowsManager.OnClickPlay += ClickPlayHandler;
            _levelController.OnLevelComplite += LevelCompliteHandler;
        }

        private void Start()
        {
            SetGameMode(false);
            _windowsManager.OpenWindowMenu();
        }

        private void ClickPlayHandler()
        {
            SetGameMode(true);
            var level = _levelStorage.GetLevel(_levelCount);
            if (level is null)
            {
                _levelCount = 0;
                level = _levelStorage.GetLevel(_levelCount);
            }

            _levelController.Init(level.Field.Words, level.Clusters);
        }

        private void LevelCompliteHandler(string[] words)
        {
            SetGameMode(false);
            _windowsManager.OpenWindowWin(words);
            _levelCount++;
        }

        public void SetGameMode(bool isGameMode)
        {
            _levelController.gameObject.SetActive(isGameMode);
            _windowsManager.gameObject.SetActive(!isGameMode);
        }

        private void OnDestroy()
        {
            _windowsManager.OnClickPlay -= ClickPlayHandler;
            _levelController.OnLevelComplite -= LevelCompliteHandler;
        }
    }
}
