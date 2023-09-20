using ToonShooterPrototype.Architecture.GameStates.Gameplay;
using ToonShooterPrototype.UI.LevelEndMenu;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers.SceneContext.Gameplay
{
    public class UiBindingsInstaller : MonoInstaller
    {
        [SerializeField] private VictoryTextMarker victoryText;
        [SerializeField] private DefeatTextMarker defeatText;
        [SerializeField] private ControlButtonsMarker controlButtons;

        public override void InstallBindings()
        {
            BindVictoryText();
            BindDefeatText();
            BindControlButtons();
        }
        
        private void BindVictoryText()
        {
            Container
                .BindInterfacesAndSelfTo<VictoryTextMarker>()
                .FromInstance(victoryText)
                .AsSingle()
                .WhenInjectedInto<VictoryGameplayState>();
        }
        
        private void BindDefeatText()
        {
            Container
                .BindInterfacesAndSelfTo<DefeatTextMarker>()
                .FromInstance(defeatText)
                .AsSingle()
                .WhenInjectedInto<DefeatGameplayState>();
        }
        
        private void BindControlButtons()
        {
            Container
                .BindInterfacesAndSelfTo<ControlButtonsMarker>()
                .FromInstance(controlButtons)
                .AsSingle()
                .WhenInjectedInto(typeof(VictoryGameplayState), typeof(DefeatGameplayState));
        }
    }
}