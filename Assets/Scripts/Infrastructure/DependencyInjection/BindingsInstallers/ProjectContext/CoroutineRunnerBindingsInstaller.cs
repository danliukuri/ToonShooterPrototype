using Unity.VisualScripting;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class CoroutineRunnerBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindCoroutineRunner();

        private void BindCoroutineRunner() =>
            Container.BindInterfacesTo<CoroutineRunner>().FromNewComponentOnNewGameObject().AsSingle();
    }
}