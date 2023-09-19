using System;
using System.Collections.Generic;
using ToonShooterPrototype.Data.Dynamic;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyAnimationActivator : IInitializable, IDisposable, ITickable
    {
        private readonly IEnumerable<EnemyData> _enemies;

        public EnemyAnimationActivator(IEnumerable<EnemyData> enemies) => _enemies = enemies;

        public void Initialize()
        {
            foreach (EnemyData enemy in _enemies)
                enemy.Health.ValueChangedToDefault += enemy.AnimationChanger.Death;
        }

        public void Dispose()
        {
            foreach (EnemyData enemy in _enemies)
                enemy.Health.ValueChangedToDefault -= enemy.AnimationChanger.Death;
        }

        public void Tick()
        {
            foreach (EnemyData enemy in _enemies)
            {
                enemy.AnimationChanger.IsWalking = enemy.Agent.hasPath;
                enemy.AnimationChanger.IsShooting = enemy.HasShootTarget;
            }
        }
    }
}