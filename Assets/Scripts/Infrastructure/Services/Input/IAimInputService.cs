using System;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public interface IAimInputService
    {
        event Action AimButtonPressed;
        event Action AimButtonReleased;
    }
}