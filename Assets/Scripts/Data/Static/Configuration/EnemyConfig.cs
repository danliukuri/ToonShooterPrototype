using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configuration/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public float SightRange { get; private set; }
        [field: SerializeField, Min(default)] public float ShotAccuracy { get; private set; }
        [field: SerializeField, Min(default)] public float ShootRange { get; private set; }
        [field: SerializeField, Min(default)] public float ShootDelay { get; private set; }
        [field: SerializeField, Min(default)] public float ShootHeight { get; private set; }
    }
}