using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace ToonShooterPrototype.Features.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyDataProvider : MonoBehaviour
    {
        public EnemyData Data { get; private set; }
        
        [Inject]
        public void Construct(EnemyData data) => Data = data;

        private void Awake()
        {
            Data.Agent = GetComponent<NavMeshAgent>();
            Data.Transform = GetComponent<Transform>();
        }
    }
}