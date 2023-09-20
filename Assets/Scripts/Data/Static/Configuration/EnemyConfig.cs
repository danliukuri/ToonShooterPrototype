using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(EnemyConfig), menuName = "Configuration/Enemy")]
    public class EnemyConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public float SightRange { get; private set; }
        [field: SerializeField, Min(default)] public float PreferableDistanceToTarget { get; private set; }
        [field: SerializeField, Min(default)] public float ShootHeight { get; private set; }

        [field: SerializeField, Min(default)] public int Health { get; private set; }
    }
}