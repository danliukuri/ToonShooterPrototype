using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using ToonShooterPrototype.Infrastructure.Creation.Services;
using UnityEngine;

namespace ToonShooterPrototype.Features.Player
{
    internal class PlayerConfigurator : IComponentConfigurator<PlayerDataProvider>
    {
        private readonly PlayerConfig _playerConfig;
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(PlayerConfig playerConfig, Transform spawnPoint)
        {
            _playerConfig = playerConfig;
            _spawnPoint = spawnPoint;
        }

        public void Configure(PlayerDataProvider component)
        {
            PlayerData data = component.Data;
            data.Config = _playerConfig;
            data.CharacterController = component.GetComponent<CharacterController>();
            data.Transform = component.GetComponent<Transform>();
            data.Transform.position = _spawnPoint.position;
        }
    }
}