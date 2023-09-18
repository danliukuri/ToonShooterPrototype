using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configuration/Player/Data")]
    public class PlayerConfig : ScriptableObject, IShooterData
    {
        [field: SerializeField, Min(default)] public float MoveSpeed { get; private set; }
        [field: SerializeField, Min(default)] public float SprintSpeed { get; private set; }
        [field: SerializeField, Min(default)] public float JumpPower { get; private set; }

        [field: SerializeField, Min(default)] public float ShotAccuracy { get; private set; }
        [field: SerializeField, Min(default)] public float ShootRange { get; private set; }
        [field: SerializeField, Min(default)] public float ShootDelay { get; private set; }
        [field: SerializeField, Min(default)] public float ShootHeight { get; private set; }
    }
}