using System.Collections.Generic;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Bullets;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyAi : ITickable
    {
        private readonly IEnumerable<EnemyData> _enemies;
        private readonly PlayerData _player;
        private readonly IRaycastBulletShooter _shooter;

        public EnemyAi(PlayerData player, IEnumerable<EnemyData> enemies, IRaycastBulletShooter shooter)
        {
            _shooter = shooter;
            _player = player;
            _enemies = enemies;
        }

        public void Tick()
        {
            foreach (EnemyData enemy in _enemies)
            {
                Transform target = _player.Transform;
                float distanceToTarget = Vector3.Distance(enemy.Transform.position, target.position);
                bool isTargetInSightRange = distanceToTarget <= enemy.Config.SightRange;
                enemy.HasShootTarget = distanceToTarget <= enemy.Weapon.Config.ShootRange;

                if (isTargetInSightRange)
                    ChasePlayer(enemy);
                if (enemy.HasShootTarget)
                {
                    RotateTowards(enemy, target.position);
                    if (_shooter.IsAbleToShoot)
                        _shooter.Shoot(enemy.Weapon,
                            target.position + enemy.Config.ShootHeight * Vector3.up);
                }
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