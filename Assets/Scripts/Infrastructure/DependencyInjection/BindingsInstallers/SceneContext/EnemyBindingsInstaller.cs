using System.Linq;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Data.Static.Configuration.Creation;
using ToonShooterPrototype.Features.Bullets;
using ToonShooterPrototype.Features.Enemy;
using ToonShooterPrototype.Infrastructure.Creation.Factories;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class EnemyBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform bulletsVFXContainer;
        [SerializeField] private FactoryConfig bulletsVFXFactoryConfig;
        [SerializeField] private PoolConfig bulletsVFXPoolConfig;
        
        
        [SerializeField] private EnemyDataProvider[] enemies;
        [SerializeField] private EnemyConfig enemyConfig;

        public override void InstallBindings()
        {
            BindConfiguration();
            BindData();

            BindAi();
            BindBulletsVfxFactory();
            BindBulletsVfxPool();
            BindShooter();
        }

        private void BindConfiguration()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyConfig>()
                .FromScriptableObject(enemyConfig)
                .AsSingle()
                .WhenInjectedInto<EnemyData>();
        }

        private void BindData()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyData>()
                .AsTransient()
                .WhenInjectedInto<EnemyDataProvider>();
        }

        private void BindAi()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyAi>()
                .AsSingle()
                .WithArguments(enemies.Select(enemy => enemy.Data));
        }

        private void BindBulletsVfxFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(bulletsVFXFactoryConfig)
                .AsCached()
                .WhenInjectedInto<IComponentFactory<EnemyBulletsVfxMarker>>();

            Container
                .BindInterfacesTo<ComponentFactory<EnemyBulletsVfxMarker>>()
                .AsSingle()
                .WithArguments(bulletsVFXContainer);
        }

        private void BindBulletsVfxPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(bulletsVFXPoolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<EnemyBulletsVfxMarker>>();

            Container
                .Bind<IObjectPool<EnemyBulletsVfxMarker>>()
                .To<ObjectPool<EnemyBulletsVfxMarker>>()
                .FromFactory<ComponentPoolFactory<EnemyBulletsVfxMarker>>()
                .AsSingle();
        }

        private void BindShooter()
        {
            Container
                .BindInterfacesTo<EnemyShooter>()
                .AsSingle()
                .WhenInjectedInto<EnemyAi>();
        }
    }
}