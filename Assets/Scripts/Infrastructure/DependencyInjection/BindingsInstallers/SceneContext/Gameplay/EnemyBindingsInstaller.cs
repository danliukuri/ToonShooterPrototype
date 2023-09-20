using ToonShooterPrototype.Architecture.GameStates.Gameplay;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Features.Enemy;
using ToonShooterPrototype.Features.Marksman;
using ToonShooterPrototype.Utilities.Wrappers;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.Gameplay
{
    public class EnemyBindingsInstaller : MonoInstaller
    {
        [SerializeField] private EnemyDataProvider[] enemies;
        [SerializeField] private EnemyConfig enemyConfig;

        public override void InstallBindings()
        {
            BindConfiguration();
            BindData();

            BindAnimationChanger();

            foreach (EnemyDataProvider enemy in enemies)
            {
                BindAi(enemy);
                BindAnimationActivator(enemy);
                BindDisabler(enemy);
            }

            BindEnemies();
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
                .BindInterfacesTo<ObservableValue<int>>()
                .AsTransient()
                .WithArguments(enemyConfig.Health)
                .WhenInjectedInto<EnemyData>();

            Container
                .BindInterfacesAndSelfTo<EnemyData>()
                .AsTransient()
                .WhenInjectedInto<EnemyDataProvider>();
        }

        private void BindAnimationChanger()
        {
            Container
                .BindInterfacesAndSelfTo<MarksmanAnimationChanger>()
                .AsTransient()
                .WhenInjectedInto<EnemyData>();
        }

        private void BindAi(EnemyDataProvider enemy)
        {
            Container
                .BindInterfacesAndSelfTo<EnemyAi>()
                .AsCached()
                .WithArguments(enemy);
        }

        private void BindAnimationActivator(EnemyDataProvider enemy)
        {
            Container
                .BindInterfacesTo<EnemyAnimationActivator>()
                .AsCached()
                .WithArguments(enemy);
        }

        private void BindDisabler(EnemyDataProvider enemy)
        {
            Container
                .BindInterfacesTo<EnemyDisabler>()
                .AsCached()
                .WithArguments(enemy)
                .WhenInjectedInto(typeof(InitializableManager), typeof(DisposableManager));
        }

        private void BindEnemies()
        {
            Container
                .BindInterfacesAndSelfTo<EnemyDataProvider[]>()
                .FromInstance(enemies)
                .AsSingle()
                .WhenInjectedInto<ProcessGameplayState>();
        }
    }
}