using System;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Bullets;
using ToonShooterPrototype.Infrastructure.Services.Input;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerShooter : IInitializable, IDisposable
    {
        private readonly PlayerData _playerData;
        private readonly PlayerInventoryData _inventory;
        private readonly PlayerCameraData _playerCamera;
        private readonly IRaycastBulletShooter _shooter;
        private readonly IShootInputService _shootInputService;
        
        public PlayerShooter(PlayerData playerData, PlayerInventoryData inventory, PlayerCameraData playerCamera,
            IShootInputService shootInputService, IRaycastBulletShooter shooter)
        {
            _playerData = playerData;
            _inventory = inventory;
            _playerCamera = playerCamera;
            _shooter = shooter;
            _shootInputService = shootInputService;
        }

        public void Dispose() => _shootInputService.ShootButtonHeldDown -= TryToShoot;

        public void Initialize() => _shootInputService.ShootButtonHeldDown += TryToShoot;

        private void TryToShoot()
        {
            if (_playerCamera.ViewPoint.HasValue && _playerData.IsGrounded && _shooter.IsAbleToShoot)
                _shooter.Shoot(_inventory.CurrentWeapon, _playerCamera.ViewPoint.Value);
        }
    }
}