using ToonShooterPrototype.Features.Player;
using ToonShooterPrototype.Utilities.Patterns.State;
using UnityEngine.Pool;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        private readonly IObjectPool<PlayerDataProvider> _playerPool;

        public SetupGameplayState(IObjectPool<PlayerDataProvider> playerPool) => _playerPool = playerPool;

        public void Enter() => _playerPool.Get();
    }
}