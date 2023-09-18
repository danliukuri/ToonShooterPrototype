using System;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public class ShootInputService : ITickable, IShootInputService
    {
        private const string ShootButtonName = "Fire1";
        
        public event Action ShootButtonPressed;
        
        public void Tick()
        {
            if (UnityEngine.Input.GetButtonDown(ShootButtonName))
                ShootButtonPressed?.Invoke();
        }
    }
}