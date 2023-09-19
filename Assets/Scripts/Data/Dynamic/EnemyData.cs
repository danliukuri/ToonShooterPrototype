using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Features.Marksman;
using ToonShooterPrototype.Utilities.Wrappers;
using UnityEngine;
using UnityEngine.AI;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class EnemyData : IDamageable
    {
        public EnemyData(EnemyConfig config, IObservableValue<int> health, IMarksmanAnimationChanger animationChanger)
        {
            Config = config;
            Health = health;
            AnimationChanger = animationChanger;
        }

        public EnemyConfig Config { get; }
        public ShootingWeaponData Weapon { get; set; }

        public Transform Transform { get; set; }
        public NavMeshAgent Agent { get; set; }

        public IMarksmanAnimationChanger AnimationChanger { get; set; }

        public bool HasShootTarget { get; set; }

        public IObservableValue<int> Health { get; set; }
    }
}