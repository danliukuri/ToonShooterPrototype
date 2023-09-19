using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Utilities.Wrappers;
using UnityEngine;
using UnityEngine.AI;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class EnemyData : IDamageable
    {
        public EnemyData(EnemyConfig config, IObservableValue<int> health)
        {
            Config = config;
            Health = health;
        }

        public EnemyConfig Config { get; }
        public ShootingWeaponData Weapon { get; set; }

        public Transform Transform { get; set; }
        public NavMeshAgent Agent { get; set; }

        public IObservableValue<int> Health { get; set; }
    }
}