using System;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public class ShootInputService : ITickable, IShootInputService
    {
        private const string ShootButtonName = "Fire1";
        
        public event Action ShootButtonHeldDown;
        
        public void Tick()
        {
            if (UnityEngine.Input.GetButton(ShootButtonName))
                ShootButtonHeldDown?.Invoke();
        }
    }
}