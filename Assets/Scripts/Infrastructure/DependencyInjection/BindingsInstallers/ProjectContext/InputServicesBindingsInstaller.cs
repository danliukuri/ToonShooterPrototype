using ToonShooterPrototype.Infrastructure.Services.Input;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class InputServicesBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings() => BindMovementInputService();

        private void BindMovementInputService() => Container.BindInterfacesTo<MovementInputService>().AsSingle();
    }
}