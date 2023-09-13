using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration.Creation
{
    [CreateAssetMenu(fileName = nameof(FactoryConfig), menuName = "Configuration/Creation/Factory")]
    public class FactoryConfig : ScriptableObject, IFactoryConfig
    {
        [field: SerializeField] public GameObject Prefab { get; private set; }
    }
}