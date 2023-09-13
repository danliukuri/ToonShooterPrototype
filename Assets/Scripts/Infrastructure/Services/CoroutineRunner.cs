using System.Collections;
using UnityEngine;

namespace ToonShooterPrototype.Infrastructure.Services
{
    public class CoroutineRunner : MonoBehaviour, ICoroutineRunner
    {
        public Coroutine Run(IEnumerator routine) => StartCoroutine(routine);

        public void Stop(Coroutine coroutine) => StopCoroutine(coroutine);
    }
}