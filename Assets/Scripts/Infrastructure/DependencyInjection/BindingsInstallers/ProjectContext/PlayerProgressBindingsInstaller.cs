using ToonShooterPrototype.Architecture.Bootstrap;
using ToonShooterPrototype.Architecture.GameStates.Gameplay;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.SaveSystem;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.ProjectContext
{
    public class PlayerProgressBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerProgressData();
            BindStringToFileSaver();
            BindPlayerProgressSaver();
        }

        private void BindStringToFileSaver()
        {
            Container
                .BindInterfacesTo<StringToStringToFileSaver>()
                .AsSingle()
                .WhenInjectedInto<PlayerProgressSaver>();
        }

        private void BindPlayerProgressSaver()
        {
            Container
                .BindInterfacesTo<PlayerProgressSaver>()
                .AsSingle()
                .WhenInjectedInto(typeof(SavingGameplayState), typeof(MainMenuSceneBootstrapper));
        }

        private void BindPlayerProgressData()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerProgressData>()
                .AsSingle()
                .WhenInjectedInto(typeof(PlayerProgressSaver), typeof(MainMenuSceneBootstrapper),
                    typeof(VictoryGameplayState), typeof(DefeatGameplayState), typeof(SavingGameplayState));
        }
    }
}