using UnityEngine;
using UnityEngine.Pool;

namespace ToonShooterPrototype.Features.Bullets
{
    public class RaycastBulletVfxSpawner : IRaycastBulletVfxSpawner
    {
        private readonly IObjectPool<RaycastBulletsVfxMarker> _bulletsVfxPool;

        public RaycastBulletVfxSpawner(IObjectPool<RaycastBulletsVfxMarker> bulletsVfxPool) =>
            _bulletsVfxPool = bulletsVfxPool;

        public void Spawn(RaycastHit hit)
        {
            RaycastBulletsVfxMarker raycastBulletsVfx = _bulletsVfxPool.Get();
            raycastBulletsVfx.transform.position = hit.point;
            raycastBulletsVfx.transform.rotation = Quaternion.LookRotation(hit.normal);
        }
    }
}