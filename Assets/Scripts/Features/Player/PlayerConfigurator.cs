using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Infrastructure.Creation.Services;
using ToonShooterPrototype.Utilities.Wrappers;
using UnityEngine;

namespace ToonShooterPrototype.Features.Player
{
    internal class PlayerConfigurator : IComponentConfigurator<PlayerDataProvider>
    {
        private readonly PlayerCameraData _camera;
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(PlayerCameraData camera, Transform spawnPoint)
        {
            _camera = camera;
            _spawnPoint = spawnPoint;
        }

        public void Configure(PlayerDataProvider component)
        {
            PlayerData data = component.Data;

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