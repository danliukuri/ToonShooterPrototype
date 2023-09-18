using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;

namespace ToonShooterPrototype.Features.Enemy
{
    public interface IEnemyShooter
    {
        void Shoot(EnemyData enemy, Vector3 targetPosition);
        bool IsAbleToShoot { get; }
    }
}