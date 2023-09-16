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

        public event Action JumpButtonPressed;
        public IObservableValue<float> HorizontalAxis { get; } = new ObservableValue<float>();
        public IObservableValue<float> VerticalAxis { get; } = new ObservableValue<float>();

        public void Tick()
        {
            HorizontalAxis.Value = UnityEngine.Input.GetAxis(HorizontalAxisName);
            VerticalAxis.Value = UnityEngine.Input.GetAxis(VerticalAxisName);

            if (UnityEngine.Input.GetButtonDown(JumpButtonName))
                JumpButtonPressed?.Invoke();
        }
    }
}