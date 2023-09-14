using ToonShooterPrototype.Utilities.Wrappers;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Services.Input
{
    public class MovementInputService : IMovementInputService, ITickable
    {
        private const string HorizontalAxisName = "Horizontal";
        private const string VerticalAxisName = "Vertical";
        
        public IObservableValue<float> HorizontalAxis { get; } = new ObservableValue<float>();
        public IObservableValue<float> VerticalAxis { get; } = new ObservableValue<float>();

        public void Tick()
        {
            HorizontalAxis.Value = UnityEngine.Input.GetAxis(HorizontalAxisName);
            VerticalAxis.Value = UnityEngine.Input.GetAxis(VerticalAxisName);
        }
    }
}