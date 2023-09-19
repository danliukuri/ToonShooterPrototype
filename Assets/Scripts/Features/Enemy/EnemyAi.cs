using System.Collections.Generic;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Bullets;
using ToonShooterPrototype.Features.Marksman;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyAi : ITickable
    {
        private readonly IEnumerable<EnemyData> _enemies;
        private readonly PlayerData _player;
        private readonly IRaycastBulletShooter _shooter;

        public EnemyAi(PlayerData player, IEnumerable<EnemyData> enemies,
            IRaycastBulletShooter shooter)
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
                bool isPlayerInShootRange = distanceToPlayer <= enemy.Weapon.Config.ShootRange;

                if (isPlayerInSightRange)
                    ChasePlayer(enemy);
                if (isPlayerInShootRange)
                {
                    RotateTowards(enemy, _player.Transform.position);
                    if (_shooter.IsAbleToShoot)
                        _shooter.Shoot(enemy.Weapon,
                            _player.Transform.position + enemy.Config.ShootHeight * Vector3.up);
                }

                enemy.AnimationChanger.IsWalking = enemy.Agent.hasPath;
                enemy.AnimationChanger.IsShooting = isPlayerInShootRange;
            }
        }

        private void ChasePlayer(EnemyData enemy) => enemy.Agent.SetDestination(_player.Transform.position);

        private void RotateTowards(EnemyData enemy, Vector3 point)
        {
            point.y = enemy.Transform.position.y;
            enemy.Transform.LookAt(point);
        }
    }
}