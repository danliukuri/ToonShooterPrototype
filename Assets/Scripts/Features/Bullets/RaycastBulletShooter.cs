﻿using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Infrastructure.Services;
using UnityEngine;

namespace ToonShooterPrototype.Features.Bullets
{
    public class RaycastBulletShooter : IRaycastBulletShooter
    {
        private readonly IRaycastBulletVfxSpawner _bulletVfxSpawner;
        private readonly ICoroutineRunner _coroutineRunner;

        public bool IsAbleToShoot { get; private set; } = true;

        public RaycastBulletShooter(IRaycastBulletVfxSpawner bulletVfxSpawner, ICoroutineRunner coroutineRunner)
        {
            _bulletVfxSpawner = bulletVfxSpawner;
            _coroutineRunner = coroutineRunner;
        }

        public void Shoot(ShootingWeaponData weapon, Vector3 targetPosition)
        {
            targetPosition += Random.insideUnitSphere * weapon.Config.ShotAccuracy;
            Vector3 shootPosition = weapon.BulletsSpawnPoint.position;
            var ray = new Ray(shootPosition, targetPosition - shootPosition);

            if (Physics.Raycast(ray, out RaycastHit hit, weapon.Config.ShootRange))
            {
                _bulletVfxSpawner.Spawn(hit);
                if (hit.collider.TryGetComponent(out IDamageableProvider damageableProvider))
                    DoDamage(weapon, damageableProvider);
            }

            IsAbleToShoot = false;
            _coroutineRunner.RunInvoke(() => IsAbleToShoot = true, weapon.Config.ShootDelay);
        }

        private static void DoDamage(ShootingWeaponData weapon, IDamageableProvider damageableProvider)
        {
            int newHealth = damageableProvider.Damageable.Health.Value - weapon.Config.ShootDamage;
            damageableProvider.Damageable.Health.Value = newHealth < default(int) ? default : newHealth;
        }
    }
}