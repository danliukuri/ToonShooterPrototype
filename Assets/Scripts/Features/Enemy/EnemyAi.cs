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

        public EnemyAi(PlayerData player, IEnumerable<EnemyData> enemies)
        {
            _player = player;
            _enemies = enemies;
        }

        public void Tick()
        {
            foreach (EnemyData enemy in _enemies)
            {
                bool isPlayerInSightRange = Vector3.Distance(enemy.Transform.position, _player.Transform.position) <=
                                            enemy.Config.SightRange;

                if (isPlayerInSightRange)
                    ChasePlayer(enemy);
            }
        }

        private void ChasePlayer(EnemyData enemy) => enemy.Agent.SetDestination(_player.Transform.position);
    }
}