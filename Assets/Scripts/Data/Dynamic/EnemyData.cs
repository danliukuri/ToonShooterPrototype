using System;
using System.Collections.Generic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Features.Marksman;
using ToonShooterPrototype.Utilities.Wrappers;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

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
        public Collider Collider { get; set; }
        public NavMeshAgent Agent { get; set; }

        public IMarksmanAnimationChanger AnimationChanger { get; set; }
        
        public IList<ITickable> TickableServices { get; } = new List<ITickable>();
        public IList<IDisposable> DisposableServices { get; } = new List<IDisposable>();

        public bool HasShootTarget { get; set; }
        public bool IsTargetAlive { get; set; }

        public IObservableValue<int> Health { get; set; }
    }
}