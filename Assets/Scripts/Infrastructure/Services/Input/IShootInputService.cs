using System;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public interface IShootInputService
    {
        event Action ShootButtonHeldDown;
        event Action ShootButtonPressed;
        event Action ShootButtonReleased;
    }
}