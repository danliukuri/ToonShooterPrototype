using System;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Infrastructure.Services.Input;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerMover : IInitializable, IDisposable, ITickable
    {
        private readonly IMovementInputService _movementInputService;
        private readonly PlayerData _player;

        private Vector3 _movementForce;
        private bool _isNeededToMove;

        public PlayerMover(IMovementInputService movementInputService, PlayerData player)
        {
            _movementInputService = movementInputService;
            _player = player;
        }

        public void Initialize()
        {
            _movementInputService.HorizontalAxis.ValueUpdated += MovePlayerHorizontally;
            _movementInputService.VerticalAxis.ValueUpdated += MovePlayerVertically;
        }

        public void Dispose()
        {
            _movementInputService.HorizontalAxis.ValueUpdated -= MovePlayerHorizontally;
            _movementInputService.VerticalAxis.ValueUpdated -= MovePlayerVertically;
        }

        public void Tick()
        {
            if (_isNeededToMove)
                MovePlayer(_movementForce.normalized * _player.Config.MoveSpeed * Time.deltaTime);
        }

        private void MovePlayerVertically(float value)
        {
            _movementForce.z = value;
            _isNeededToMove = true;
        }

        private void MovePlayerHorizontally(float value)
        {
            _movementForce.x = value;
            _isNeededToMove = true;
        }

        private void MovePlayer(Vector3 movementForce)
        {
            _player.CharacterController.Move(movementForce);
            _isNeededToMove = false;
        }
    }
}