using System;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyDisabler : IInitializable, IDisposable
    {
        private readonly EnemyDataProvider _enemy;
        private readonly TickableManager _tickableManager;

        public EnemyDisabler(EnemyDataProvider enemy, TickableManager tickableManager)
        {
            _tickableManager = tickableManager;
            _enemy = enemy;
        }

        public void Initialize() => _enemy.Data.Health.ValueChangedToDefault += DisableEnemy;

        public void Dispose() => _enemy.Data.Health.ValueChangedToDefault -= DisableEnemy;

        private void DisableEnemy(int health)
        {
            _enemy.Data.Agent.enabled = false;
            _enemy.Data.Collider.enabled = false;

            foreach (ITickable tickable in _enemy.Data.TickableServices)
                _tickableManager.Remove(tickable);

            foreach (IDisposable disposable in _enemy.Data.DisposableServices)
                disposable.Dispose();
        }
    }
}