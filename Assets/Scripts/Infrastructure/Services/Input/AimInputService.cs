using System;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public class AimInputService : ITickable, IAimInputService
    {
        private const string AimButtonName = "Fire2";

        public event Action AimButtonPressed;
        public event Action AimButtonReleased;

        public void Tick()
        {
            if (UnityEngine.Input.GetButtonDown(AimButtonName))
                AimButtonPressed?.Invoke();
            if (UnityEngine.Input.GetButtonUp(AimButtonName))
                AimButtonReleased?.Invoke();
        }
    }
}