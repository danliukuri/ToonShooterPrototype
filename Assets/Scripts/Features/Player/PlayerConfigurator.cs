﻿using ToonShooterPrototype.Infrastructure.Creation.Services;
using UnityEngine;

namespace ToonShooterPrototype.Features.Player
{
    internal class PlayerConfigurator : IComponentConfigurator<PlayerDataProvider>
    {
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(Transform spawnPoint) => _spawnPoint = spawnPoint;

        public void Configure(PlayerDataProvider component) => component.transform.position = _spawnPoint.position;
    }
}