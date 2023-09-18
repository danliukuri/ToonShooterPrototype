using UnityEngine;
using UnityEngine.Pool;
using Zenject;

namespace ToonShooterPrototype.Features.Bullets
{
    public class RaycastBulletsVfxPoolReturner : MonoBehaviour
    {
        private IObjectPool<RaycastBulletsVfxPoolReturner> _pool;
        
        [Inject]
        public void Construct(IObjectPool<RaycastBulletsVfxPoolReturner> pool) => _pool = pool;

        private void OnDisable() => _pool.Release(this);
    }
}