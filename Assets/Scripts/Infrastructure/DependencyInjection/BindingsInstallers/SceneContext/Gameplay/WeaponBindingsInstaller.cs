using System;
using System.Collections.Generic;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Features.Weapon;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.Gameplay
{
    public class WeaponBindingsInstaller : MonoInstaller
    {
        [SerializeField] private ShootingWeaponConfig pistolConfig;
        [SerializeField] private ShootingWeaponConfig smgConfig;
        [SerializeField] private ShootingWeaponConfig sniper2Config;

        public override void InstallBindings()
        {
            List<(ShootingWeaponConfig Config, Type Marker)> shootingWeapons = new()
            {
                (pistolConfig,  typeof(PistolMarker) ),
                (smgConfig,     typeof(SmgMarker)    ),
                (sniper2Config, typeof(Sniper2Marker))
            };

            shootingWeapons.ForEach(BindShootingWeaponData);
        }

        private void BindShootingWeaponData((ShootingWeaponConfig Config, Type Marker) weapon)
        {
            Container
                .BindInterfacesAndSelfTo<ShootingWeaponData>()
                .AsTransient()
                .WithArguments(weapon.Config)
                .When(ctx => ctx.WhenInjectedInto<ShootingWeaponDataProvider>() && ctx.HasComponent(weapon.Marker));
        }
    }
}