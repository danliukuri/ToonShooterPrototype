using System;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Marksman;
using ToonShooterPrototype.Infrastructure.Services.Input;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerAnimationActivator : IInitializable, IDisposable
    {
        private readonly IMarksmanAnimationChanger _animationChanger;
        private readonly IMovementInputService _movementInputService;
        private readonly PlayerData _player;
        private readonly IShootInputService _shootInputService;

        public PlayerAnimationActivator(IMarksmanAnimationChanger animationChanger,
            IMovementInputService movementInputService, PlayerData player, IShootInputService shootInputService)
        {
            _animationChanger = animationChanger;
            _player = player;
            _movementInputService = movementInputService;
            _shootInputService = shootInputService;
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

            _player.Health.ValueChangedToDefault -= Death;
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

            _player.Health.ValueChangedToDefault += Death;
        }

        private void StartWalking((float X, float Y) axes) => _animationChanger.IsWalking = true;
        private void StopWalking((float X, float Y) axes) => _animationChanger.IsWalking = false;

        private void StartRunning() => _animationChanger.IsRunning = true;
        private void StopRunning() => _animationChanger.IsRunning = false;

        private void StartShooting() => _animationChanger.IsShooting = true;
        private void StopShooting() => _animationChanger.IsShooting = false;

        private void ChangeShootingSpeed(int index) =>
            _animationChanger.ShootingSpeed = 1f / _player.Inventory.ShootingWeapons[index].Config.ShootDelay;

        private void Jump()
        {
            if (_player.CharacterController.isGrounded)
                _animationChanger.Jump();
        }

        private void Death(int health) => _animationChanger.Death();
    }
}