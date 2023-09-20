using ToonShooterPrototype.Architecture.GameStates.Gameplay;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Features.Environment;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.Gameplay
{
    public class EnvironmentBindingInstaller : MonoInstaller
    {
        [SerializeField] private EnvironmentConfig environmentConfig;

        public override void InstallBindings()
        {
            BindEnvironmentConfig();
            BindGravityForceApplier();
        }

        private void BindEnvironmentConfig()
        {
            Container
                .BindInterfacesAndSelfTo<EnvironmentConfig>()
                .FromScriptableObject(environmentConfig)
                .AsSingle()
                .WhenInjectedInto<GravityForceApplier>();
        }

        private void BindGravityForceApplier()
        {
            Container
                .BindInterfacesTo<GravityForceApplier>()
                .AsSingle()
                .WhenInjectedInto(typeof(TickableManager), typeof(SetupGameplayState));
        }
    }
}