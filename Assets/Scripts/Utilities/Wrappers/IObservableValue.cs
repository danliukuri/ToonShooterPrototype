using System;

namespace ToonShooterPrototype.Utilities.Wrappers
{
    public interface IObservableValue<T>
    {
        T Value { get; set; }
        event Action<T> ValueChanged;
        event Action<T> ValueUpdated;
    }
}