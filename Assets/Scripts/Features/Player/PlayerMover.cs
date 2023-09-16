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

        public PlayerMover(IMovementInputService movementInputService, PlayerData player)
        {
            _movementInputService = movementInputService;
            _player = player;
        }

        public void Initialize()
        {
            _movementInputService.HorizontalAxis.ValueUpdated += MoveHorizontally;
            _movementInputService.VerticalAxis.ValueUpdated += MoveVertically;
            _movementInputService.JumpButtonPressed += Jump;
        }

        public void Dispose()
        {
            _movementInputService.HorizontalAxis.ValueUpdated -= MoveHorizontally;
            _movementInputService.VerticalAxis.ValueUpdated -= MoveVertically;
            _movementInputService.JumpButtonPressed -= Jump;
        }

        public void Tick() => MovePlayer((CalculateMovementForce() + _player.JumpingForce) * Time.deltaTime);

        private void MoveHorizontally(float value) => _player.MovementForce.x = value;

        private void MoveVertically(float value) => _player.MovementForce.z = value;

        private void Jump()
        {
            if (_player.IsGrounded)
            {
                _player.JumpingForce.y = _player.Config.JumpPower;
                _player.IsGrounded = false;
            }
        }

        private void MovePlayer(Vector3 movementForce)
        {
            _player.CharacterController.Move(movementForce);
            _player.IsGrounded = _player.CharacterController.isGrounded;
        }

        private Vector3 CalculateMovementForce()
        {
            Vector3 relativeMovementForce = _player.MovementForce.x * _player.Transform.right +
                                            _player.MovementForce.z * _player.Transform.forward;

            return relativeMovementForce.normalized * _player.Config.MoveSpeed;
        }
    }
}