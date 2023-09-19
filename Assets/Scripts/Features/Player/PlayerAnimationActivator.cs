using System;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Infrastructure.Services.Input;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerAnimationActivator : IInitializable, IDisposable
    {
        private readonly IMovementInputService _movementInputService;
        private readonly PlayerData _player;
        private readonly IShootInputService _shootInputService;

        public bool IsWalking
        {
            get => _player.Animator.GetBool(nameof(IsWalking));
            set => _player.Animator.SetBool(nameof(IsWalking), value);
        }

        public bool IsRunning
        {
            get => _player.Animator.GetBool(nameof(IsRunning));
            set => _player.Animator.SetBool(nameof(IsRunning), value);
        }

        public bool IsShooting
        {
            get => _player.Animator.GetBool(nameof(IsShooting));
            set => _player.Animator.SetBool(nameof(IsShooting), value);
        }

        public float ShootingSpeed
        {
            get => _player.Animator.GetFloat(nameof(ShootingSpeed));
            set => _player.Animator.SetFloat(nameof(ShootingSpeed), value);
        }
        
        public bool IsGrounded
        {
            get => _player.Animator.GetBool(nameof(IsGrounded));
            set => _player.Animator.SetBool(nameof(IsGrounded), value);
        }

        public PlayerAnimationActivator(IMovementInputService movementInputService, PlayerData player,
            IShootInputService shootInputService)
        {
            _player = player;
            _movementInputService = movementInputService;
            _shootInputService = shootInputService;
        }

        public void Initialize()
        {
            _movementInputService.Axles.ValueChanged += StartWalking;
            _movementInputService.Axles.ValueChangedToDefault += StopWalking;
            
            _movementInputService.SprintButtonPressed += StartRunning;
            _movementInputService.SprintButtonReleased += StopRunning;
            
            _movementInputService.JumpButtonPressed += Jump;
            
            _shootInputService.ShootButtonPressed += StartShooting;
            _shootInputService.ShootButtonReleased += StopShooting;
            _player.Inventory.CurrentWeaponIndex.ValueChanged += ChangeShootingSpeed;
        }

        public void Dispose()
        {
            _movementInputService.Axles.ValueChanged -= StartWalking;
            _movementInputService.Axles.ValueChangedToDefault -= StopWalking;
            
            _movementInputService.SprintButtonPressed -= StartRunning;
            _movementInputService.SprintButtonReleased -= StopRunning;
            
            _movementInputService.JumpButtonPressed -= Jump;
            
            _shootInputService.ShootButtonPressed -= StartShooting;
            _shootInputService.ShootButtonReleased -= StopShooting;
        }

        private void StartWalking((float X, float Y) axes) => IsWalking = true;
        private void StopWalking((float X, float Y) axes) => IsWalking = false;

        private void StartRunning() => IsRunning = true;
        private void StopRunning() => IsRunning = false;

        private void StartShooting() => IsShooting = true;
        private void StopShooting() => IsShooting = false;
        private void ChangeShootingSpeed(int index) =>
            ShootingSpeed = 1f / _player.Inventory.ShootingWeapons[index].Config.ShootDelay;

        private void Jump()
        {
            if (_player.CharacterController.isGrounded)
                _player.Animator.SetTrigger(nameof(Jump));
        }
    }
}