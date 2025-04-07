using naa.AssemblingWords.Data;
using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Installers
{
    public class ConfigManagerInstaller : MonoInstaller
    {
        [SerializeField] private ConfigManager _configManager;

        public override void InstallBindings()
        {
            Container.Bind<ConfigManager>().FromInstance(_configManager).AsSingle();
        }
    }
}
