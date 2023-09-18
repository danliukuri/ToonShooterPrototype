using System.Collections.Generic;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class PlayerInventoryData
    {
        public IList<ShootingWeaponData> ShootingWeapons { get; set; }
        public ShootingWeaponData CurrentWeapon { get; set; }
    }
}