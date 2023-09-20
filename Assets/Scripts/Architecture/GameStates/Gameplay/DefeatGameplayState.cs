using ToonShooterPrototype.UI.LevelEndMenu;
using ToonShooterPrototype.Utilities.Patterns.State;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class DefeatGameplayState : IEnterableState
    {
        private readonly ControlButtonsMarker _controlButtons;
        private readonly DefeatTextMarker _defeatText;

        public DefeatGameplayState(ControlButtonsMarker controlButtons, DefeatTextMarker defeatText)
        {
            _controlButtons = controlButtons;
            _defeatText = defeatText;
        }

        public void Enter()
        {
            _controlButtons.gameObject.SetActive(true);
            _defeatText.gameObject.SetActive(true);
        }
    }
}