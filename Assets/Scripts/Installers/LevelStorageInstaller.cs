using naa.AssemblingWords.Data;
using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Installers
{
    public class LevelStorageInstaller : MonoInstaller
    {
        [SerializeField] private LevelStorage _levelStorage;

        public override void InstallBindings()
        {
            Container.Bind<LevelStorage>().FromInstance(_levelStorage).AsSingle();
        }
    }
}
