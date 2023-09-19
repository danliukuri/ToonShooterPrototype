using ToonShooterPrototype.Data.Dynamic;

namespace ToonShooterPrototype.Features
{
    public interface IDamageableProvider
    {
        IDamageable Damageable { get; }
    }
}