using System;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyAnimationActivator : IInitializable, IDisposable, ITickable
    {
        private readonly EnemyDataProvider _enemy;

        public EnemyAnimationActivator(EnemyDataProvider enemy) => _enemy = enemy;

        public void Initialize() => _enemy.Data.Health.ValueChangedToDefault += _enemy.Data.AnimationChanger.Death;

        public void Dispose() => _enemy.Data.Health.ValueChangedToDefault -= _enemy.Data.AnimationChanger.Death;

        public void Tick()
        {
            _enemy.Data.AnimationChanger.IsWalking = _enemy.Data.Agent.hasPath;
            _enemy.Data.AnimationChanger.IsShooting = _enemy.Data.HasShootTarget;
        }
    }
}