using naa.AssemblingWords.Game;
using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Installers
{
    public class GameControllerInstaller : MonoInstaller
    {
        [SerializeField] private GameController _gameController;

        public override void InstallBindings()
        {
            Container.Bind<GameController>().FromInstance(_gameController).AsSingle();
        }
    }
}
