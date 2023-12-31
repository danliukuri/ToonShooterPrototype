﻿using System;
using System.Collections.Generic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Utilities.Wrappers;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class PlayerData : IGroundable, IDamageable
    {
        public PlayerData(PlayerInventoryData inventory, PlayerConfig config, IObservableValue<int> health)
        {
            Config = config;
            Inventory = inventory;
            MoveSpeed = config.MoveSpeed;
            Health = health;
        }

        public Transform Transform { get; set; }
        public CharacterController CharacterController { get; set; }

        public PlayerInventoryData Inventory { get; }
        public PlayerConfig Config { get; }

        public IList<ITickable> TickableServices { get; } = new List<ITickable>();
        public IList<ILateTickable> LateTickableServices { get; } = new List<ILateTickable>();
        public IList<IDisposable> DisposableServices { get; } = new List<IDisposable>();

        public IObservableValue<int> Health { get; }

        public float MoveSpeed { get; set; }
        public bool IsGrounded { get; set; }

        private Vector3 _movementForce;
        public ref Vector3 MovementForce => ref _movementForce;

        private Vector3 _jumpingForce;
        public ref Vector3 JumpingForce => ref _jumpingForce;
    }
}