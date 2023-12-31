﻿using System;
using ToonShooterPrototype.Utilities.Wrappers;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public interface IMovementInputService
    {
        IObservableValue<float> HorizontalAxis { get; }
        IObservableValue<float> VerticalAxis { get; }
        IObservableValue<(float X, float Y)> Axles { get; }
        event Action JumpButtonPressed;
        event Action SprintButtonPressed;
        event Action SprintButtonReleased;
    }
}