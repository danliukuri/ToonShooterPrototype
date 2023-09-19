using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Marksman;
using ToonShooterPrototype.Infrastructure.Creation.Services;
using UnityEngine;

namespace ToonShooterPrototype.Features.Player
{
    internal class PlayerConfigurator : IComponentConfigurator<PlayerDataProvider>
    {
        private readonly IMarksmanAnimationChanger _animationChanger;
        private readonly PlayerCameraData _camera;
        private readonly Transform _spawnPoint;

        public PlayerConfigurator(IMarksmanAnimationChanger animationChanger, PlayerCameraData camera,
            Transform spawnPoint)
        {
            _animationChanger = animationChanger;
            _camera = camera;
            _spawnPoint = spawnPoint;
        }

        public void Configure(PlayerDataProvider component)
        {
            PlayerData data = component.Data;

            data.CharacterController = component.GetComponent<CharacterController>();
            _animationChanger.Animator = component.GetComponentInChildren<Animator>();
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