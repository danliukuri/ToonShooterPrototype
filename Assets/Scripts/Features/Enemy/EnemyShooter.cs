using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Bullets;
using ToonShooterPrototype.Infrastructure.Services;
using UnityEngine;
using UnityEngine.Pool;
using Random = UnityEngine.Random;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyShooter : IEnemyShooter
    {
        private readonly IObjectPool<EnemyBulletsVfxMarker> _enemyBulletsVfxPool;
        private readonly ICoroutineRunner _coroutineRunner;

        public bool IsAbleToShoot { get; private set; } = true;

        public EnemyShooter(IObjectPool<EnemyBulletsVfxMarker> enemyBulletsVfxPool, ICoroutineRunner coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            _enemyBulletsVfxPool = enemyBulletsVfxPool;
        }

        public void Shoot(EnemyData enemy, Vector3 targetPosition)
        {
            targetPosition += Random.insideUnitSphere * enemy.Config.ShotAccuracy;

            Vector3 shootPosition = enemy.BulletsSpawnPoint.position;
            var ray = new Ray(shootPosition, targetPosition - shootPosition);
            
            if (Physics.Raycast(ray, out RaycastHit hit, enemy.Config.ShootRange))
                SpawnHitVfx(ray, hit);

            IsAbleToShoot = false;
            _coroutineRunner.RunInvoke(() => IsAbleToShoot = true, enemy.Config.ShootDelay);
        }

        private void SpawnHitVfx(Ray ray, RaycastHit hit)
        {
            EnemyBulletsVfxMarker enemyBulletsVfx = _enemyBulletsVfxPool.Get();
            enemyBulletsVfx.transform.position = hit.point;
            enemyBulletsVfx.transform.rotation = Quaternion.LookRotation(-ray.direction);
        }
    }
}