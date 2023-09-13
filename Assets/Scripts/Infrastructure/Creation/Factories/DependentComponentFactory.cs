using ToonShooterPrototype.Data.Static.Configuration.Creation;
using ToonShooterPrototype.Infrastructure.Creation.Services;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.Creation.Factories
{
    public class DependentComponentFactory<TComponent> : ComponentFactory<TComponent> where TComponent : Component
    {
        private readonly IInstantiator _instantiator;

        public DependentComponentFactory(IFactoryConfig config, IInstantiator instantiator,
            IComponentConfigurator<TComponent> configurator = default,
            Transform objectParent = default,
            IComponentResetter<TComponent> resetter = default) : base(config, configurator, objectParent, resetter) =>
            _instantiator = instantiator;

        public override TComponent Create() =>
            _config.Prefab.AsInactive(_instantiator.InstantiatePrefabForComponent<TComponent>, _objectParent);
    }
}