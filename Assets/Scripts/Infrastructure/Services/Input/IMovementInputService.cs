using System;
using ToonShooterPrototype.Utilities.Wrappers;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public interface IMovementInputService
    {
        IObservableValue<float> HorizontalAxis { get; }
        IObservableValue<float> VerticalAxis { get; }
        event Action JumpButtonPressed;
    }
}