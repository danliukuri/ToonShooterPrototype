using UnityEngine;

namespace ToonShooterPrototype.Infrastructure.Creation.Services
{
    public interface IComponentResetter<in TComponent> where TComponent : Component
    {
        void Reset(TComponent component);
    }
}