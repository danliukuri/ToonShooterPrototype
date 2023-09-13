using UnityEngine;

namespace ToonShooterPrototype.Infrastructure.Creation.Services
{
    public interface IComponentConfigurator<in TComponent> where TComponent : Component
    {
        public void Configure(TComponent component);
    }
}