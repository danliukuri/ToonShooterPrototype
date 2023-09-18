using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Infrastructure.Creation.Services;
using UnityEngine;

namespace ToonShooterPrototype.Features.Player
{
    internal class PlayerConfigurator : IComponentConfigurator<PlayerDataProvider>
    {
        private readonly PlayerCameraData _camera;
        private readonly PlayerInventoryData _inventory;
        private readonly PlayerConfig _playerConfig;
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(PlayerCameraData camera, PlayerInventoryData inventory, PlayerConfig playerConfig,
            Transform spawnPoint)
        {
            _inventory = inventory;
            _camera = camera;
            _playerConfig = playerConfig;
            _spawnPoint = spawnPoint;
        }

        public void Configure(PlayerDataProvider component)
        {
            PlayerData data = component.Data;

            data.Config = _playerConfig;
            data.Inventory = _inventory;
            data.MoveSpeed = _playerConfig.MoveSpeed;

            data.CharacterController = component.GetComponent<CharacterController>();

            data.Transform = component.GetComponent<Transform>();
            data.Transform.position = _spawnPoint.position;

            ConfigureCamera(data.Transform);
        }

        private void ConfigureCamera(Transform player)
        {
            _camera.FreeLook.Follow = _camera.FreeLook.LookAt = player;
            _camera.Aim.Follow = _camera.Aim.LookAt = player;
        }
    }
}