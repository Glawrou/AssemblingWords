using naa.AssemblingWords.Windows;
using UnityEngine;
using Zenject;

namespace naa.AssemblingWords.Installers
{
    public class WindowsManagerInstaller : MonoInstaller
    {
        [SerializeField] private WindowsManager _windowsManager;

        public override void InstallBindings()
        {
            Container.Bind<WindowsManager>().FromInstance(_windowsManager).AsSingle();
        }
    }
}
