using Cinemachine;
using ToonShooterPrototype.Architecture.GameStates.Gameplay;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Data.Static.Configuration.Creation;
using ToonShooterPrototype.Features.Enemy;
using ToonShooterPrototype.Features.Marksman;
using ToonShooterPrototype.Features.Player;
using ToonShooterPrototype.Infrastructure.Creation.Factories;
using ToonShooterPrototype.Utilities.Wrappers;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class PlayerBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private FactoryConfig factoryConfig;
        [SerializeField] private PoolConfig poolConfig;

        [SerializeField] private CinemachineFreeLook freeLookCamera;
        [SerializeField] private CinemachineFreeLook aimCamera;
        [SerializeField] private Transform playerCamera;
        [SerializeField] private PlayerCameraConfig playerCameraConfig;

        public override void InstallBindings()
        {
            BindConfigurator();
            BindFactory();
            BindObjectPool();

            BindData();
            BindInventoryData();
            BindCameraData();

            BindMover();
            PlayerRotator();
            BindViewSwitcher();
            BindShooter();
            BindWeaponSwitcher();
            BindDisabler();
            
            BindAnimationChanger();
            BindAnimationActivator();
        }

        private void BindConfigurator()
        {
            Container
                .BindInterfacesTo<PlayerConfigurator>()
                .AsSingle()
                .WithArguments(spawnPoint)
                .WhenInjectedInto<DependentComponentFactory<PlayerDataProvider>>();
        }

        private void BindFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(factoryConfig)
                .AsCached()
                .WhenInjectedInto<DependentComponentFactory<PlayerDataProvider>>();

            Container.BindInterfacesTo<DependentComponentFactory<PlayerDataProvider>>().AsSingle();
        }

        private void BindObjectPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(poolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<PlayerDataProvider>>();

            Container
                .Bind<IObjectPool<PlayerDataProvider>>()
                .To<ObjectPool<PlayerDataProvider>>()
                .FromFactory<ComponentPoolFactory<PlayerDataProvider>>()
                .AsSingle();
        }

        private void BindData()
        {
            Container
                .BindInterfacesTo<ObservableValue<int>>()
                .AsCached()
                .WithArguments(playerConfig.Health)
                .WhenInjectedInto<PlayerData>();

            Container
                .BindInterfacesAndSelfTo<PlayerData>()
                .AsSingle()
                .WithArguments(playerConfig)
                .WhenInjectedInto(typeof(PlayerDataProvider), typeof(PlayerMover), typeof(PlayerRotator),
                    typeof(EnemyAi), typeof(PlayerShooter), typeof(PlayerAnimationActivator), typeof(PlayerShooter),
                    typeof(PlayerWeaponSwitcher), typeof(PlayerDisabler), typeof(ProcessGameplayState));
        }

        private void BindInventoryData()
        {
            Container
                .BindInterfacesTo<ObservableValue<int>>()
                .AsCached()
                .WhenInjectedInto<PlayerInventoryData>();

            Container
                .BindInterfacesAndSelfTo<PlayerInventoryData>()
                .AsSingle()
                .WhenInjectedInto(typeof(PlayerData), typeof(PlayerWeaponSwitcher), typeof(PlayerShooter));
        }

        private void BindCameraData()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerCameraData>()
                .AsSingle()
                .WithArguments(playerCameraConfig, playerCamera, freeLookCamera, aimCamera)
                .WhenInjectedInto(typeof(PlayerConfigurator), typeof(PlayerViewSwitcher), typeof(PlayerRotator),
                    typeof(PlayerShooter));
        }

        private void BindMover() => Container.BindInterfacesTo<PlayerMover>().AsSingle();

        private void PlayerRotator() => Container.BindInterfacesTo<PlayerRotator>().AsSingle();

        private void BindWeaponSwitcher() => Container.BindInterfacesTo<PlayerWeaponSwitcher>().AsSingle();

        private void BindShooter() => Container.BindInterfacesTo<PlayerShooter>().AsSingle();

        private void BindViewSwitcher() => Container.BindInterfacesTo<PlayerViewSwitcher>().AsSingle();

        private void BindDisabler()
        {
            Container
                .BindInterfacesTo<PlayerDisabler>()
                .AsSingle()
                .WhenInjectedInto<ProcessGameplayState>();
        }

        private void BindAnimationChanger()
        {
            Container
                .BindInterfacesTo<MarksmanAnimationChanger>()
                .AsCached()
                .WhenInjectedInto(typeof(PlayerConfigurator), typeof(PlayerAnimationActivator), typeof(PlayerDisabler));
        }

        private void BindAnimationActivator() => Container.BindInterfacesTo<PlayerAnimationActivator>().AsSingle();
    }
}