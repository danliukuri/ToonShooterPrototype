using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Environment;
using ToonShooterPrototype.Features.Player;
using ToonShooterPrototype.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly IGroundableObjectsEffector _groundableObjectsEffector;
        private readonly IObjectPool<PlayerDataProvider> _playerPool;

        public SetupGameplayState(IGroundableObjectsEffector groundableObjectsEffector,
            IObjectPool<PlayerDataProvider> playerPool)
        {
            _groundableObjectsEffector = groundableObjectsEffector;
            _playerPool = playerPool;
        }

        public void Enter()
        {
            PlayerData player = _playerPool.Get().Data;
            _groundableObjectsEffector.GroundableObjects.Add(player);
        }
    }
}