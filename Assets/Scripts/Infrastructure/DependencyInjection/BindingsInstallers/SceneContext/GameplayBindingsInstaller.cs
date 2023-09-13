using System;
using System.Collections.Generic;
using ToonShooterPrototype.Architecture.Bootstrap;
using ToonShooterPrototype.Architecture.GameStates.Gameplay;
using ToonShooterPrototype.Utilities.Patterns.State.Containers;
using ToonShooterPrototype.Utilities.Patterns.State.Machines;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext
{
    public class GameplayBindingsInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStates();
            BindStatesContainer();
            BindStateMachine();
        }

        private void BindStates()
        {
            var gameStatesTypes = new List<Type> { typeof(SetupGameplayState) };
            gameStatesTypes.ForEach(BindState());

            Action<Type> BindState() => stateType =>
                Container.BindInterfacesTo(stateType).AsSingle().WhenInjectedInto<StatesContainerInitializer>();
        }

        private void BindStatesContainer()
        {
            Container
                .BindInterfacesTo<StateContainer>()
                .AsSingle()
                .WhenInjectedInto(typeof(StateMachine), typeof(StatesContainerInitializer));

            Container.BindInterfacesTo<StatesContainerInitializer>().AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .BindInterfacesTo<StateMachine>()
                .AsSingle()
                .WhenInjectedInto(typeof(SceneBootstrapper));
        }
    }
}