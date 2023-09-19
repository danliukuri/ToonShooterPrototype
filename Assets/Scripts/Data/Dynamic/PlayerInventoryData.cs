using System.Collections.Generic;
using ToonShooterPrototype.Utilities.Wrappers;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class PlayerInventoryData
    {
        public PlayerInventoryData(IObservableValue<int> currentWeaponIndex) => CurrentWeaponIndex = currentWeaponIndex;
        public IList<ShootingWeaponData> ShootingWeapons { get; set; }
        public ShootingWeaponData CurrentWeapon => ShootingWeapons[CurrentWeaponIndex.Value];
        public IObservableValue<int> CurrentWeaponIndex { get; private set; }
    }
}