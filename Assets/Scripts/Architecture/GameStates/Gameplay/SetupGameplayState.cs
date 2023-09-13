using ToonShooterPrototype.Utilities.Patterns.State;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class SetupGameplayState : IEnterableState
    {
        public void Enter() => UnityEngine.Debug.Log(nameof(SetupGameplayState) + nameof(Enter));
    }
}