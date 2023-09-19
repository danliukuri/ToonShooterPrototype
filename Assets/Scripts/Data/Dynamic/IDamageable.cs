using ToonShooterPrototype.Utilities.Wrappers;

namespace ToonShooterPrototype.Data.Dynamic
{
    public interface IDamageable
    {
        IObservableValue<int> Health { get; }
    }
}