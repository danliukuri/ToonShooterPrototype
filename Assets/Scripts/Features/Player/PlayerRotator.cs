using System.Linq;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerRotator : ILateTickable
    {
        private readonly PlayerCameraConfig _cameraConfig;
        private readonly PlayerData _player;

        public PlayerRotator(PlayerCameraConfig cameraConfig, PlayerData player)
        {
            _cameraConfig = cameraConfig;
            _player = player;
        }

        public void LateTick() => RotatePlayer();

        private void RotatePlayer()
        {
            Vector3 playerNewRotation = Quaternion.LookRotation(GetViewDirection()).eulerAngles;
            Vector3 playerRotation = _player.Transform.rotation.eulerAngles;
            playerNewRotation.x = playerRotation.x;
            playerNewRotation.z = playerRotation.z;

            _player.Transform.rotation = Quaternion.Euler(playerNewRotation);
        }

        private Vector3 GetViewDirection()
        {
            Vector3 cameraDirection = _player.Camera.forward;
            var ray = new Ray(_player.Camera.position, cameraDirection);

            return Physics.Raycast(ray, out RaycastHit hit, _cameraConfig.MaxViewDistance) &&
                   _cameraConfig.AttractiveObjectsTags.Any(hit.collider.CompareTag)
                ? hit.point - _player.Transform.position
                : cameraDirection;
        }
    }
}