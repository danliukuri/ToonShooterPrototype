using ToonShooterPrototype.Data.Dynamic;
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

        public void Shoot(IShooterData data, Vector3 shootPosition, Vector3 targetPosition)
        {
            targetPosition += Random.insideUnitSphere * data.ShotAccuracy;
            var ray = new Ray(shootPosition, targetPosition - shootPosition);

            Debug.DrawRay(shootPosition, targetPosition - shootPosition, Color.red, 1f);
            if (Physics.Raycast(ray, out RaycastHit hit, data.ShootRange))
                _bulletVfxSpawner.Spawn(hit);

            IsAbleToShoot = false;
            _coroutineRunner.RunInvoke(() => IsAbleToShoot = true, data.ShootDelay);
        }
    }
}