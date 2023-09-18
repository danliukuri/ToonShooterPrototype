using ToonShooterPrototype.Infrastructure.Services.Input;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class InputServicesBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMovementInputService();
            BindAimInputService();
            BindShootInputService();
        }

        private void BindMovementInputService() => Container.BindInterfacesTo<MovementInputService>().AsSingle();

        private void BindAimInputService() => Container.BindInterfacesTo<AimInputService>().AsSingle();

        private void BindShootInputService() => Container.BindInterfacesTo<ShootInputService>().AsSingle();
    }
}