using ToonShooterPrototype.UI.LevelEndMenu;
using ToonShooterPrototype.Utilities.Patterns.State;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class VictoryGameplayState : IEnterableState
    {
        private readonly ControlButtonsMarker _controlButtons;
        private readonly VictoryTextMarker _victoryText;

        public VictoryGameplayState(ControlButtonsMarker controlButtons, VictoryTextMarker victoryText)
        {
            _controlButtons = controlButtons;
            _victoryText = victoryText;
        }

        public void Enter()
        {
            _controlButtons.gameObject.SetActive(true);
            _victoryText.gameObject.SetActive(true);
        }
    }
}