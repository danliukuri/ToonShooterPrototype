using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.UI.LevelEndMenu;
using ToonShooterPrototype.Utilities.Patterns.State;
using ToonShooterPrototype.Utilities.Patterns.State.Machines;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class VictoryGameplayState : IEnterableState
    {
        private readonly ControlButtonsMarker _controlButtons;
        private readonly PlayerProgressData _playerProgressData;
        private readonly VictoryTextMarker _victoryText;
        private readonly IStateMachine _stateMachine;

        public VictoryGameplayState(ControlButtonsMarker controlButtons, PlayerProgressData playerProgressData,
            VictoryTextMarker victoryText, IStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
            _playerProgressData = playerProgressData;
            _controlButtons = controlButtons;
            _victoryText = victoryText;
        }

        public void Enter()
        {
            _controlButtons.gameObject.SetActive(true);
            _victoryText.gameObject.SetActive(true);

            _playerProgressData.WinCount++;

            _stateMachine.ChangeStateTo<SavingGameplayState>();
        }
    }
}