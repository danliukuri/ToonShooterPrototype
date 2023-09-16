using System;

namespace ToonShooterPrototype.Utilities.Wrappers
{
    public class ObservableValue<T> : IObservableValue<T> where T : IEquatable<T>
    {
        private T _value;

        public T Value
        {
            get => _value;
            set
            {
                T previousValue = _value;
                if (!previousValue.Equals(value))
                {
                    _value = value;
                    ValueChanged?.Invoke(value);
                }
                ValueUpdated?.Invoke(value);
            }
        }

        public event Action<T> ValueChanged;
        public event Action<T> ValueUpdated;
    }
}