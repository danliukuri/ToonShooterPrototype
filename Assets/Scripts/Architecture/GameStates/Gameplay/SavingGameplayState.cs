using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.SaveSystem;
using ToonShooterPrototype.Utilities.Patterns.State;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class SavingGameplayState : IEnterableState
    {
        private readonly PlayerProgressData _playerProgressData;
        private readonly IPlayerProgressSaver _playerProgressSaver;

        public SavingGameplayState(PlayerProgressData playerProgressData, IPlayerProgressSaver playerProgressSaver)
        {
            _playerProgressData = playerProgressData;
            _playerProgressSaver = playerProgressSaver;
        }

        public void Enter() => _playerProgressSaver.Save(_playerProgressData);
    }
}