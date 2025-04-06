using UnityEngine;
using Zenject;
using naa.AssemblingWords.Game;

namespace naa.AssemblingWords.Installers
{
    public class LevelControllerInstaller : MonoInstaller
    {
        [SerializeField] private LevelController _levelController;

        public override void InstallBindings()
        {
            Container.Bind<LevelController>().FromInstance(_levelController).AsSingle();
        }
    }
}
