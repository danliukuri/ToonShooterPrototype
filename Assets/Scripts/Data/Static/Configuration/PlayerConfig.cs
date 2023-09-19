using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configuration/Player/Data")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public float MoveSpeed { get; private set; }
        [field: SerializeField, Min(default)] public float SprintSpeed { get; private set; }
        [field: SerializeField, Min(default)] public float JumpPower { get; private set; }

        [field: SerializeField, Min(default)] public int Health { get; private set; }
    }
}