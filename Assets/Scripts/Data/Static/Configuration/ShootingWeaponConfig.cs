using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(ShootingWeaponConfig), menuName = "Configuration/Weapon/ShootingWeapon")]
    public class ShootingWeaponConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public float ShotAccuracy { get; private set; }
        [field: SerializeField, Min(default)] public float ShootRange { get; private set; }
        [field: SerializeField, Min(default)] public float ShootDelay { get; private set; }
        [field: SerializeField, Min(default)] public int ShootDamage { get; private set; }
    }
}