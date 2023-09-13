using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration.Creation
{
    public interface IFactoryConfig
    {
        GameObject Prefab { get; }
    }
}