using System.Threading.Tasks;
using Unity.Services.RemoteConfig;
using Unity.Services.Authentication;
using Unity.Services.Core;
using UnityEngine;
using System;

namespace naa.AssemblingWords.Data
{
    public class ConfigManager : MonoBehaviour
    {
        public bool IsInit {  get; private set; }
        public struct UserAttributes { }
        public struct AppAttributes { }

        private const string LevelsConfigKey = "levels";

        private string LevelsJson;

        private async void Start()
        {
            try
            {
                if (await TryInitializeRemoteConfig())
                {
                    await FetchRemoteConfig();
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Remote Config initialization failed: {e.Message}");
            }

            IsInit = true;
        }

        public string GetLevels()
        {
            return LevelsJson;
        }

        private async Task<bool> TryInitializeRemoteConfig()
        {
            if (!Utilities.CheckForInternetConnection())
            {
                return false;
            }

            try
            {
                await UnityServices.InitializeAsync();
                if (!AuthenticationService.Instance.IsSignedIn)
                {
                    await AuthenticationService.Instance.SignInAnonymouslyAsync();
                }

                return true;
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Services initialization failed: {e.Message}");
                return false;
            }
        }

        private async Task FetchRemoteConfig()
        {
            RemoteConfigService.Instance.FetchCompleted += RemoteConfigFetched;
            await RemoteConfigService.Instance.FetchConfigsAsync(
                new UserAttributes(),
                new AppAttributes()
            );

            RemoteConfigService.Instance.FetchCompleted -= RemoteConfigFetched;
        }

        private void RemoteConfigFetched(ConfigResponse response)
        {
            if (response.status == ConfigRequestStatus.Success)
            {
                LevelsJson = RemoteConfigService.Instance.appConfig.GetJson(LevelsConfigKey);
            }
            else
            {
                Debug.LogWarning($"Remote Config fetch failed: {response.status}");
            }
        }

        private void OnDestroy()
        {
            RemoteConfigService.Instance.FetchCompleted -= RemoteConfigFetched;
        }
    }
}