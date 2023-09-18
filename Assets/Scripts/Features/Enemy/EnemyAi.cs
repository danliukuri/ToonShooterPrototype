using System.Collections.Generic;
using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyAi : ITickable
    {
        private readonly IEnumerable<EnemyData> _enemies;
        private readonly PlayerData _player;
        private readonly IEnemyShooter _shooter;

        public EnemyAi(PlayerData player, IEnumerable<EnemyData> enemies, IEnemyShooter shooter)
        {
            _shooter = shooter;
            _player = player;
            _enemies = enemies;
        }

        public void Tick()
        {
            foreach (EnemyData enemy in _enemies)
            {
                float distanceToPlayer = Vector3.Distance(enemy.Transform.position, _player.Transform.position);
                bool isPlayerInSightRange = distanceToPlayer <= enemy.Config.SightRange;
                bool isPlayerInShootRange = distanceToPlayer <= enemy.Config.ShootRange;

                if (isPlayerInSightRange)
                    ChasePlayer(enemy);
                if (isPlayerInShootRange && _shooter.IsAbleToShoot)
                    _shooter.Shoot(enemy, _player.Transform.position + enemy.Config.ShootHeight * Vector3.up);
            }
        }

        private void ChasePlayer(EnemyData enemy) => enemy.Agent.SetDestination(_player.Transform.position);
    }
}