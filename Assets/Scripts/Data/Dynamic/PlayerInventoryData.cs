using System.Collections.Generic;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class PlayerInventoryData
    {
        public IList<ShootingWeaponData> ShootingWeapons { get; set; }
        public ShootingWeaponData CurrentWeapon => ShootingWeapons[CurrentWeaponIndex];
        public int CurrentWeaponIndex { get; set; }
    }
}