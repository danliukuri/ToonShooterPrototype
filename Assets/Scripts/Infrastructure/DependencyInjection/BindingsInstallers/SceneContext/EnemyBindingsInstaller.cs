using System.Linq;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Features.Enemy;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class EnemyBindingsInstaller : MonoInstaller
    {
        [SerializeField] private EnemyDataProvider[] enemies;
        [SerializeField] private EnemyConfig enemyConfig;

        public override void InstallBindings()
        {
            BindConfiguration();
            BindData();

            BindAi();
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
    }
}