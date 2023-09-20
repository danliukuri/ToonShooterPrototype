using ToonShooterPrototype.Utilities.Patterns.State;

namespace ToonShooterPrototype.Architecture.GameStates.Gameplay
{
    public class DefeatGameplayState : IEnterableState
    {
        public void Enter() => UnityEngine.Debug.Log(nameof(DefeatGameplayState) + "." + nameof(Enter));
    }
}