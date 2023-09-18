using ToonShooterPrototype.Data.Static.Configuration;
using UnityEngine;
using UnityEngine.AI;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class EnemyData
    {
        public EnemyData(EnemyConfig config) => Config = config;

        public EnemyConfig Config { get; }
        
        public Transform Transform { get; set; }
        public Transform BulletsSpawnPoint { get; set; }
        public NavMeshAgent Agent { get; set; }
    }
}