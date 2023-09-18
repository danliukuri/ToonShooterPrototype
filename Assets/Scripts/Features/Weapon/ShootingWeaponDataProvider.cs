using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Weapon
{
    public class ShootingWeaponDataProvider : MonoBehaviour, IShootingWeaponDataProvider
    {
        [SerializeField] private Transform bulletsSpawnPoint;
        public ShootingWeaponData Data { get; private set; }

        [Inject]
        public void Construct(ShootingWeaponData data)
        {
            Data = data;
            Data.BulletsSpawnPoint = bulletsSpawnPoint;
        }
    }
}