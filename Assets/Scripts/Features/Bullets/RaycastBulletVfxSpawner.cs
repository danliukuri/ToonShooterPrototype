using UnityEngine;
using UnityEngine.Pool;

namespace ToonShooterPrototype.Features.Bullets
{
    public class RaycastBulletVfxSpawner : IRaycastBulletVfxSpawner
    {
        private readonly IObjectPool<RaycastBulletsVfxPoolReturner> _bulletsVfxPool;

        public RaycastBulletVfxSpawner(IObjectPool<RaycastBulletsVfxPoolReturner> bulletsVfxPool) =>
            _bulletsVfxPool = bulletsVfxPool;

        public void Spawn(RaycastHit hit)
        {
            RaycastBulletsVfxPoolReturner raycastBulletsVfx = _bulletsVfxPool.Get();
            raycastBulletsVfx.transform.position = hit.point;
            raycastBulletsVfx.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}