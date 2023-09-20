using ToonShooterPrototype.Architecture.Bootstrap;
using ToonShooterPrototype.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.MainMenu
{
    public class UiBindingsInstaller : MonoInstaller
    {
        [SerializeField] private VictoryCountTextProvider victoryCountTextProvider;
        [SerializeField] private DefeatCountTextProvider defeatCountTextProvider;

        public override void InstallBindings()
        {
            BindVictoryCountTextProvider();
            BindDefeatCountTextProvider();
        }

        private void BindVictoryCountTextProvider()
        {
            Container
                .Bind<VictoryCountTextProvider>()
                .FromInstance(victoryCountTextProvider)
                .AsSingle()
                .WhenInjectedInto<MainMenuSceneBootstrapper>();
        }

        private void BindDefeatCountTextProvider()
        {
            Container
                .Bind<DefeatCountTextProvider>()
                .FromInstance(defeatCountTextProvider)
                .AsSingle()
                .WhenInjectedInto<MainMenuSceneBootstrapper>();
        }
    }
}