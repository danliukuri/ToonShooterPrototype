using System;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public interface IAlphaButtonsInputService
    {
        event Action<int> AlphaButtonPressed;
    }
}