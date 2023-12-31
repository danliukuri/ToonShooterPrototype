﻿using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Bullets;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    public class EnemyAi : IInitializable, ITickable
    {
        private readonly EnemyDataProvider _enemyProvider;
        private readonly PlayerData _player;
        private readonly IRaycastBulletShooter _shooter;

        public EnemyAi(PlayerData player, EnemyDataProvider enemyProvider, IRaycastBulletShooter shooter)
        {
            _enemyProvider = enemyProvider;
            _shooter = shooter;
            _player = player;
        }

        public void Initialize() => _enemyProvider.Data.TickableServices.Add(this);

        public void Tick()
        {
            EnemyData enemy = _enemyProvider.Data;

            float distanceToTarget = Vector3.Distance(enemy.Transform.position, _player.Transform.position);
            bool isTargetInSightRange = distanceToTarget <= enemy.Config.SightRange;
            enemy.HasShootTarget = distanceToTarget <= enemy.Weapon.Config.ShootRange;
            enemy.IsTargetAlive = _player.Health.Value > default(int);
            
            if (isTargetInSightRange && enemy.IsTargetAlive)
                ChasePlayer(enemy);
            if (enemy.HasShootTarget && enemy.IsTargetAlive)
            {
                RotateTowards(enemy, _player.Transform.position);
                if (_shooter.IsAbleToShoot)
                    _shooter.Shoot(enemy.Weapon,
                        _player.Transform.position + enemy.Config.ShootHeight * Vector3.up);
            }
        }

        private void ChasePlayer(EnemyData enemy)
        {
            Vector3 target = _player.Transform.position;
            Vector3 direction = target - enemy.Transform.position;
            
            enemy.Agent.SetDestination(target - direction.normalized * enemy.Config.PreferableDistanceToTarget);
        }

        private void RotateTowards(EnemyData enemy, Vector3 point)
        {
            point.y = enemy.Transform.position.y;
            enemy.Transform.LookAt(point);
        }
    }
}