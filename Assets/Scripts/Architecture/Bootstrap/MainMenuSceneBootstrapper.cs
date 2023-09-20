using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.SaveSystem;
using ToonShooterPrototype.UI.MainMenu;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Architecture.Bootstrap
{
    public class MainMenuSceneBootstrapper : MonoBehaviour
    {
        private DefeatCountTextProvider _defeatCountTextProvider;
        private PlayerProgressData _playerProgressData;
        private IPlayerProgressLoader _playerProgressLoader;
        private VictoryCountTextProvider _victoryCountTextProvider;

        [Inject]
        private void Construct(DefeatCountTextProvider defeatCountTextProvider, PlayerProgressData playerProgressData,
            IPlayerProgressLoader playerProgressLoader, VictoryCountTextProvider victoryCountTextProvider)
        {
            _defeatCountTextProvider = defeatCountTextProvider;
            _playerProgressData = playerProgressData;
            _playerProgressLoader = playerProgressLoader;
            _victoryCountTextProvider = victoryCountTextProvider;
        }

        private async void Start()
        { 
            await _playerProgressLoader.Load(_playerProgressData);
            _victoryCountTextProvider.TextMeshPro.text = _playerProgressData.WinCount.ToString();
            _defeatCountTextProvider.TextMeshPro.text = _playerProgressData.LoseCount.ToString();
        }
    }
}