using System;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Infrastructure.Services.Input;
using ToonShooterPrototype.Utilities.Extensions;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerWeaponSwitcher : IInitializable, IDisposable
    {
        private readonly IAlphaButtonsInputService _alphaButtonsInputService;
        private readonly PlayerInventoryData _inventory;

        public PlayerWeaponSwitcher(PlayerInventoryData inventory, IAlphaButtonsInputService alphaButtonsInputService)
        {
            _inventory = inventory;
            _alphaButtonsInputService = alphaButtonsInputService;
        }

        public void Initialize() => _alphaButtonsInputService.AlphaButtonPressed += SwitchWeapon;

        public void Dispose() => _alphaButtonsInputService.AlphaButtonPressed -= SwitchWeapon;

        private void SwitchWeapon(int buttonIndex)
        {
            if (_inventory.ShootingWeapons.IsInIndexRange(buttonIndex) && _inventory.CurrentWeaponIndex != buttonIndex)
            {
                _inventory.CurrentWeapon.GameObject.SetActive(false);
                _inventory.CurrentWeaponIndex = buttonIndex;
                _inventory.CurrentWeapon.GameObject.SetActive(true);
            }
        }
    }
}