using ToonShooterPrototype.Data.Static.Configuration;
using UnityEngine;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class PlayerData : IGroundable
    {
        public Transform Transform { get; set; }
        public CharacterController CharacterController { get; set; }
        public PlayerInventoryData Inventory { get; set; }

        public PlayerConfig Config { get; set; }

        public float MoveSpeed { get; set; }
        public bool IsGrounded { get; set; }

        private Vector3 _jumpingForce;
        public ref Vector3 JumpingForce => ref _jumpingForce;

        private Vector3 _movementForce;
        public ref Vector3 MovementForce => ref _movementForce;
    }
}