using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;

namespace ToonShooterPrototype.Features.Bullets
{
    public interface IRaycastBulletShooter
    {
        public void Shoot(IShooterData data, Vector3 shootPosition, Vector3 targetPosition);
        bool IsAbleToShoot { get; }
    }
}