using System;
using ToonShooterPrototype.Utilities.Wrappers;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public class MovementInputService : IMovementInputService, ITickable
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        private const string JumpButtonName = "Jump";
        public const string SprintButtonName = "Fire3";

        public event Action JumpButtonPressed;
        public event Action SprintButtonPressed;
        public event Action SprintButtonReleased;

        public IObservableValue<float> HorizontalAxis { get; } = new ObservableValue<float>();
        public IObservableValue<float> VerticalAxis { get; } = new ObservableValue<float>();
        public IObservableValue<(float X, float Y)> Axles { get; } = new ObservableValue<(float X, float Y)>();

        public void Tick()
        {
            HorizontalAxis.Value = UnityEngine.Input.GetAxis(HorizontalAxisName);
            VerticalAxis.Value = UnityEngine.Input.GetAxis(VerticalAxisName);
            Axles.Value = (HorizontalAxis.Value, VerticalAxis.Value);

            if (UnityEngine.Input.GetButtonDown(JumpButtonName))
                JumpButtonPressed?.Invoke();
            
            if (UnityEngine.Input.GetButtonDown(SprintButtonName))
                SprintButtonPressed?.Invoke();
            if (UnityEngine.Input.GetButtonUp(SprintButtonName))
                SprintButtonReleased?.Invoke();
        }
    }
}