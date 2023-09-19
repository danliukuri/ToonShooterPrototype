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

        public bool IsWalking
        {
            get => _player.Animator.GetBool(nameof(IsWalking));
            set => _player.Animator.SetBool(nameof(IsWalking), value);
        }

        public PlayerAnimationActivator(IMovementInputService movementInputService, PlayerData player)
        {
            _player = player;
            _movementInputService = movementInputService;
        }

        public void Initialize()
        {
            _movementInputService.Axles.ValueChanged += StartWalking;
            _movementInputService.Axles.ValueChangedToDefault += StopWalking;
        }

        public void Dispose()
        {
            _movementInputService.Axles.ValueChanged -= StartWalking;
            _movementInputService.Axles.ValueChangedToDefault -= StopWalking;
        }

        private void StartWalking((float X, float Y) axes) => IsWalking = true;

        private void StopWalking((float X, float Y) axes) => IsWalking = false;
    }
}