using System.Collections;
using UnityEngine;

namespace ToonShooterPrototype.Infrastructure.Services
{
    public interface ICoroutineRunner
    {
        Coroutine Run(IEnumerator routine);
        void Stop(Coroutine coroutine);
    }
}