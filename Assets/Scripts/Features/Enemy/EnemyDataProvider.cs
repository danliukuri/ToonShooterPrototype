using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Features.Weapon;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    [RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(Transform))]
    public class EnemyDataProvider : MonoBehaviour, IDamageableProvider
    {
        public IDamageable Damageable => Data;
        public EnemyData Data { get; private set; }

        [Inject]
        public void Construct(EnemyData data) => Data = data;

        private void Awake()
        {
            Data.Agent = GetComponent<NavMeshAgent>();
            Data.Transform = GetComponent<Transform>();
            Data.Weapon = GetComponentInChildren<IShootingWeaponDataProvider>().Data;
        }
    }
}