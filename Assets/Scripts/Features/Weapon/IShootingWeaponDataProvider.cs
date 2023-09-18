using ToonShooterPrototype.Data.Dynamic;

namespace ToonShooterPrototype.Features.Weapon
{
    public interface IShootingWeaponDataProvider
    {
        ShootingWeaponData Data { get; }
    }
}