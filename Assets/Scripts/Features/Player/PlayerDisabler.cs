using System;
using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerDisabler : IInitializable, IDisposable
    {
        private readonly PlayerData _player;
        private readonly TickableManager _tickableManager;

        public PlayerDisabler(PlayerData player, TickableManager tickableManager)
        {
            _player = player;
            _tickableManager = tickableManager;
        }

        public void Initialize() => _player.Health.ValueChangedToDefault += DisableEnemy;

        public void Dispose() => _player.Health.ValueChangedToDefault -= DisableEnemy;

        private void DisableEnemy(int health)
        {
            _player.MovementForce = Vector3.zero;

            foreach (ITickable tickable in _player.TickableServices)
                _tickableManager.Remove(tickable);
            foreach (ILateTickable lateTickable in _player.LateTickableServices)
                _tickableManager.RemoveLate(lateTickable);
            foreach (IDisposable disposable in _player.DisposableServices)
                disposable.Dispose();
        }
    }
}