using System;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public class ShootInputService : ITickable, IShootInputService
    {
        private const string ShootButtonName = "Fire1";
        
        public event Action ShootButtonPressed;
        public event Action ShootButtonHeldDown;
        public event Action ShootButtonReleased;
        
        public void Tick()
        {
            if (UnityEngine.Input.GetButtonDown(ShootButtonName))
                ShootButtonPressed?.Invoke();
            if (UnityEngine.Input.GetButton(ShootButtonName))
                ShootButtonHeldDown?.Invoke();
            if (UnityEngine.Input.GetButtonUp(ShootButtonName))
                ShootButtonReleased?.Invoke();
        }
    }
}