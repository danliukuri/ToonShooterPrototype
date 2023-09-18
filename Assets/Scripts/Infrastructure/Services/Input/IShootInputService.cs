using System;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public interface IShootInputService
    {
        event Action ShootButtonPressed;
    }
}