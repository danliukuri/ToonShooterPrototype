using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Features.Weapon;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class WeaponBindingsInstaller : MonoInstaller
    {
        [SerializeField] private ShootingWeaponConfig pistolConfig;

        public override void InstallBindings() => BindPistolData();

        private void BindPistolData()
        {
            Container
                .BindInterfacesAndSelfTo<ShootingWeaponData>()
                .AsSingle()
                .WithArguments(pistolConfig)
                .When(ctx => ctx.WhenInjectedInto<ShootingWeaponDataProvider>() && ctx.HasComponent<PistolMarker>());
        }
    }
}