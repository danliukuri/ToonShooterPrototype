using System.Linq;
using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerRotator : IInitializable, ILateTickable
    {
        private readonly PlayerCameraData _camera;
        private readonly PlayerData _player;

        public PlayerRotator(PlayerCameraData camera, PlayerData player)
        {
            _camera = camera;
            _player = player;
        }

        public void Initialize() => _player.LateTickableServices.Add(this);

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
            Vector3 cameraDirection = _camera.Transform.forward;
            var ray = new Ray(_camera.Transform.position, cameraDirection);

            Vector3 viewDirection = cameraDirection;
            _camera.ViewPoint = default;

            if (Physics.Raycast(ray, out RaycastHit hit, _camera.Config.MaxViewDistance))
            {
                if(_camera.Config.AttractiveObjectsTags.Any(hit.collider.CompareTag))
                    viewDirection = hit.point - _player.Transform.position;
                _camera.ViewPoint = hit.point;
            }

            return viewDirection;
        }
    }
}