using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Utilities.Patterns.State;
using ToonShooterPrototype.Utilities.Patterns.State.Machines;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class ProcessGameplayState : IEnterableState, IExitableState
    {
        private readonly PlayerData _player;
        private readonly IStateMachine _stateMachine;
        
        public ProcessGameplayState(PlayerData player, IStateMachine stateMachine)
        {
            _player = player;
            _stateMachine = stateMachine;
        }

        public void Enter() => _player.Health.ValueChangedToDefault += ChangeStateToDefeat;

        public void Exit() => _player.Health.ValueChangedToDefault -= ChangeStateToDefeat;

        private void ChangeStateToDefeat(int playerHealth) => _stateMachine.ChangeStateTo<DefeatGameplayState>();
    }
}