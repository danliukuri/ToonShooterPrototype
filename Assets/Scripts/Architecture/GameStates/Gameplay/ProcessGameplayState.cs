using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Enemy;
using ToonShooterPrototype.Infrastructure.Services;
using ToonShooterPrototype.Utilities.Patterns.State;
using ToonShooterPrototype.Utilities.Patterns.State.Machines;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class ProcessGameplayState : IEnterableState, IExitableState
    {
        private readonly EnemyDataProvider[] _enemies;
        private readonly PlayerData _player;
        private readonly IDisabler _playerDisabler;
        private readonly IStateMachine _stateMachine;

        private int _deadEnemiesCount;

        public ProcessGameplayState(EnemyDataProvider[] enemies, PlayerData player, IStateMachine stateMachine,
            IDisabler playerDisabler)
        {
            _playerDisabler = playerDisabler;
            _enemies = enemies;
            _player = player;
            _stateMachine = stateMachine;
        }

        public void Enter()
        {
            _player.Health.ValueChangedToDefault += ChangeStateToDefeat;
            foreach (EnemyDataProvider enemy in _enemies)
                enemy.Data.Health.ValueChangedToDefault += TryToChangeStateToVictory;
        }

        public void Exit()
        {
            _player.Health.ValueChangedToDefault -= ChangeStateToDefeat;
            foreach (EnemyDataProvider enemy in _enemies)
                enemy.Data.Health.ValueChangedToDefault -= TryToChangeStateToVictory;

            _playerDisabler.Disable();
        }

        private void ChangeStateToDefeat(int playerHealth) => _stateMachine.ChangeStateTo<DefeatGameplayState>();

        private void TryToChangeStateToVictory(int enemyHealth)
        {
            if (++_deadEnemiesCount == _enemies.Length)
                _stateMachine.ChangeStateTo<VictoryGameplayState>();
        }
    }
}