using ToonShooterPrototype.Data.Static.Configuration.Creation;
using ToonShooterPrototype.Features.Bullets;
using ToonShooterPrototype.Features.Enemy;
using ToonShooterPrototype.Features.Player;
using ToonShooterPrototype.Infrastructure.Creation.Factories;
using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class BulletShooterBindingsInstaller : MonoInstaller
    {
        [SerializeField] private Transform bulletsVFXContainer;
        [SerializeField] private FactoryConfig bulletsVFXFactoryConfig;
        [SerializeField] private PoolConfig bulletsVFXPoolConfig;

        public override void InstallBindings()
        {
            BindRaycastBulletsVfxFactory();
            BindRaycastBulletsVfxPool();
            BindRaycastBulletsVfxSpawner();
            BindRaycastBulletShooter();
        }

        private void BindRaycastBulletsVfxFactory()
        {
            Container
                .BindInterfacesTo<FactoryConfig>()
                .FromScriptableObject(bulletsVFXFactoryConfig)
                .AsCached()
                .WhenInjectedInto<IComponentFactory<RaycastBulletsVfxPoolReturner>>();

            Container
                .BindInterfacesTo<DependentComponentFactory<RaycastBulletsVfxPoolReturner>>()
                .AsSingle()
                .WithArguments(bulletsVFXContainer);
        }

        private void BindRaycastBulletsVfxPool()
        {
            Container
                .BindInterfacesTo<PoolConfig>()
                .FromScriptableObject(bulletsVFXPoolConfig)
                .AsCached()
                .WhenInjectedInto<ComponentPoolFactory<RaycastBulletsVfxPoolReturner>>();

            Container
                .Bind<IInitializable>()
                .To<ComponentPoolFactory<RaycastBulletsVfxPoolReturner>>()
                .AsCached();
            
            Container
                .Bind<IObjectPool<RaycastBulletsVfxPoolReturner>>()
                .To<ObjectPool<RaycastBulletsVfxPoolReturner>>()
                .FromFactory<ComponentPoolFactory<RaycastBulletsVfxPoolReturner>>()
                .AsSingle();
        }

        private void BindRaycastBulletsVfxSpawner()
        {
            Container
                .BindInterfacesTo<RaycastBulletVfxSpawner>()
                .AsSingle()
                .WhenInjectedInto<RaycastBulletShooter>();
        }

        private void BindRaycastBulletShooter()
        {
            Container
                .BindInterfacesTo<RaycastBulletShooter>()
                .AsTransient()
                .WhenInjectedInto(typeof(PlayerShooter), typeof(EnemyAi));
        }
    }
}