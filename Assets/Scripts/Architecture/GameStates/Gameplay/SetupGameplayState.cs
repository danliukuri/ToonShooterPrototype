using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Environment;
using ToonShooterPrototype.Features.Player;
using ToonShooterPrototype.Utilities.Patterns.State;
using ToonShooterPrototype.Utilities.Patterns.State.Machines;
using UnityEngine.Pool;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly IGroundableObjectsEffector _groundableObjectsEffector;
        private readonly IObjectPool<PlayerDataProvider> _playerPool;
        private readonly IStateMachine _stateMachine;

        public SetupGameplayState(IGroundableObjectsEffector groundableObjectsEffector,
            IObjectPool<PlayerDataProvider> playerPool, IStateMachine stateMachine)
        {
            _groundableObjectsEffector = groundableObjectsEffector;
            _playerPool = playerPool;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            PlayerData player = _playerPool.Get().Data;
            _groundableObjectsEffector.GroundableObjects.Add(player);

            _stateMachine.ChangeStateTo<ProcessGameplayState>();
        }
    }
}