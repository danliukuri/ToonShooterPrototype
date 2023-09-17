using Cinemachine;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Data.Static.Configuration.Creation;
using ToonShooterPrototype.Features.Player;
using ToonShooterPrototype.Infrastructure.Creation.Factories;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class PlayerBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform spawnPoint;
        [SerializeField] private CinemachineVirtualCameraBase playerCinemachineCamera;

        [SerializeField] private PlayerConfig playerConfig;
        [SerializeField] private FactoryConfig factoryConfig;
        [SerializeField] private PoolConfig poolConfig;

        public override void InstallBindings()
        {
            BindConfigurator();
            BindFactory();
            BindObjectPool();

            BindData();
            BindConfiguration();

            BindMover();
            BindCamera();
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
                .BindInterfacesAndSelfTo<PlayerData>()
                .AsSingle()
                .WhenInjectedInto(typeof(PlayerDataProvider), typeof(PlayerMover), typeof(PlayerRotator));
        }

        private void BindConfiguration()
        {
            Container
                .BindInterfacesAndSelfTo<PlayerConfig>()
                .FromScriptableObject(playerConfig)
                .AsSingle()
                .WhenInjectedInto<PlayerConfigurator>();
        }

        private void BindMover() => Container.BindInterfacesTo<PlayerMover>().AsSingle();

        private void BindCamera()
        {
            Container
                .BindInterfacesTo<CinemachineVirtualCameraBase>()
                .FromInstance(playerCinemachineCamera)
                .AsSingle()
                .WhenInjectedInto<PlayerConfigurator>();
        }
    }
}

    