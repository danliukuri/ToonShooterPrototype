using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(EnvironmentConfig), menuName = "Configuration/Environment")]
    public class EnvironmentConfig : ScriptableObject
    {
        [field: SerializeField] public float GravityForce { get; private set; }
        [field: SerializeField] public float StickingForce { get; private set; }
    }
}