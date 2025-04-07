using Cysharp.Threading.Tasks;
using naa.AssemblingWords.Data;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace naa.AssemblingWords.Load
{
    public class LoadAndNext : MonoBehaviour
    {
        [Inject] private ConfigManager _configManager;

        private const string GameSceneName = "Game";

        private async void Start()
        {
            await LoadProcess();
            SceneManager.LoadScene(GameSceneName);
        }

        private async UniTask LoadProcess()
        {
            await UniTask.WaitUntil(() => _configManager.IsInit);
        }
    }
}
