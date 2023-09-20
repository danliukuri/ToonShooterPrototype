using ToonShooterPrototype.Utilities.Patterns.State;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class VictoryGameplayState : IEnterableState
    {
        public void Enter() => UnityEngine.Debug.Log(nameof(VictoryGameplayState) + "." + nameof(Enter));
    }
}