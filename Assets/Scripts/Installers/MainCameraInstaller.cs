using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Installers
{
    public class MainCameraInstaller : MonoInstaller
    {
        [SerializeField] private Camera _camera;

        public override void InstallBindings()
        {
            Container.Bind<Camera>().FromInstance(_camera).AsSingle();
        }
    }
}