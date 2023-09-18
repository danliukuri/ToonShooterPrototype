using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;

namespace ToonShooterPrototype.Features.Bullets
{
    public interface IRaycastBulletShooter
    {
        public void Shoot(ShootingWeaponData weapon, Vector3 targetPosition);
        bool IsAbleToShoot { get; }
    }
}