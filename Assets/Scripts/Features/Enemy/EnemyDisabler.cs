using System;
using ToonShooterPrototype.Infrastructure.Services;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyDisabler : IInitializable, IDisposable, IDisabler
    {
        private readonly EnemyDataProvider _enemy;
        private readonly TickableManager _tickableManager;

        public EnemyDisabler(EnemyDataProvider enemy, TickableManager tickableManager)
        {
            _tickableManager = tickableManager;
            _enemy = enemy;
        }

        public void Initialize() => _enemy.Data.Health.ValueChangedToDefault += Disable;

        public void Dispose() => _enemy.Data.Health.ValueChangedToDefault -= Disable;

        public void Disable()
        {
            _enemy.Data.Agent.enabled = false;
            _enemy.Data.Collider.enabled = false;

            foreach (ITickable tickable in _enemy.Data.TickableServices)
                _tickableManager.Remove(tickable);

            foreach (IDisposable disposable in _enemy.Data.DisposableServices)
                disposable.Dispose();
        }

        private void Disable(int health) => Disable();
    }
}