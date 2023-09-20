using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.UI.LevelEndMenu;
using ToonShooterPrototype.Utilities.Patterns.State;
using ToonShooterPrototype.Utilities.Patterns.State.Machines;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class DefeatGameplayState : IEnterableState
    {
        private readonly ControlButtonsMarker _controlButtons;
        private readonly DefeatTextMarker _defeatText;
        private readonly PlayerProgressData _playerProgressData;
        private readonly IStateMachine _stateMachine;

        public DefeatGameplayState(ControlButtonsMarker controlButtons, PlayerProgressData playerProgressData,
            DefeatTextMarker defeatText, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _playerProgressData = playerProgressData;
            _controlButtons = controlButtons;
            _defeatText = defeatText;
        }

        public void Enter()
        {
            _controlButtons.gameObject.SetActive(true);
            _defeatText.gameObject.SetActive(true);

            _playerProgressData.LoseCount++;

            _stateMachine.ChangeStateTo<SavingGameplayState>();
        }
    }
}