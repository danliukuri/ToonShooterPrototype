using ToonShooterPrototype.Data.Static.Configuration;
using UnityEngine;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class ShootingWeaponData
    {
        public ShootingWeaponData(ShootingWeaponConfig config) => Config = config;

        public Transform BulletsSpawnPoint { get; set; }
        public ShootingWeaponConfig Config { get; private set; }
    }
}