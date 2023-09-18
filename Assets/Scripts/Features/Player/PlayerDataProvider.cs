using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Player
{
    public class PlayerDataProvider : MonoBehaviour
    {
        [SerializeField] private Transform bulletsSpawnPoint;
        public PlayerData Data { get; private set; }

        [Inject]
        public void Construct(PlayerData data)
        {
            Data = data;
            Data.BulletsSpawnPoint = bulletsSpawnPoint;
        }
    }
}