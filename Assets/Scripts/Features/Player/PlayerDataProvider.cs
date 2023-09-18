using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Weapon;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerDataProvider : MonoBehaviour
    {
        public PlayerData Data { get; private set; }

        [Inject]
        public void Construct(PlayerData data) => Data = data;

        private void Awake()
        {
            Data.Weapon = GetComponentInChildren<IShootingWeaponDataProvider>().Data;
        }
    }
}