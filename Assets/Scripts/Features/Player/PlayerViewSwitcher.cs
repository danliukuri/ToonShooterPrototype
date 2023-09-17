using System;
using Cinemachine;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Infrastructure.Services.Input;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerViewSwitcher : IInitializable, IDisposable
    {
        private readonly IAimInputService _aimInputService;
        private readonly PlayerCameraData _camera;

        public PlayerViewSwitcher(IAimInputService aimInputService, PlayerCameraData camera)
        {
            _aimInputService = aimInputService;
            _camera = camera;
        }

        public void Dispose()
        {
            _aimInputService.AimButtonPressed -= SwitchAim;
            _aimInputService.AimButtonReleased -= SwitchAim;
        }

        public void Initialize()
        {
            _aimInputService.AimButtonPressed += SwitchAim;
            _aimInputService.AimButtonReleased += SwitchAim;
        }

        private void SwitchAim()
        {
            SynchronizeInput(_camera.FreeLook.Priority > _camera.Aim.Priority ? _camera.FreeLook : _camera.Aim);
            (_camera.FreeLook.Priority, _camera.Aim.Priority) = (_camera.Aim.Priority, _camera.FreeLook.Priority);
        }
        
        private void SynchronizeInput(CinemachineFreeLook activeCamera)
        {
            _camera.Aim.m_XAxis.Value = _camera.FreeLook.m_XAxis.Value = activeCamera.m_XAxis.Value;
            _camera.Aim.m_YAxis.Value = _camera.FreeLook.m_YAxis.Value = activeCamera.m_YAxis.Value;
        }
    }
}