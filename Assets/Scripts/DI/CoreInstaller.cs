using Service;
using Zenject;

namespace DI
{
    public class CoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<SceneHandler>().AsSingle();
        }
    }
}