using System;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Marksman;
using ToonShooterPrototype.Infrastructure.Services;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerDisabler : IDisabler
    {
        private readonly IMarksmanAnimationChanger _animationChanger;
        private readonly PlayerData _player;
        private readonly TickableManager _tickableManager;

        public PlayerDisabler(IMarksmanAnimationChanger animationChanger, PlayerData player,
            TickableManager tickableManager)
        {
            _animationChanger = animationChanger;
            _player = player;
            _tickableManager = tickableManager;
        }

        public void Disable()
        {
            _player.MovementForce = Vector3.zero;

            foreach (ITickable tickable in _player.TickableServices)
                _tickableManager.Remove(tickable);
            foreach (ILateTickable lateTickable in _player.LateTickableServices)
                _tickableManager.RemoveLate(lateTickable);
            foreach (IDisposable disposable in _player.DisposableServices)
                disposable.Dispose();

            _animationChanger.IsWalking = false;
            _animationChanger.IsRunning = false;
            _animationChanger.IsShooting = false;
        }
    }
}