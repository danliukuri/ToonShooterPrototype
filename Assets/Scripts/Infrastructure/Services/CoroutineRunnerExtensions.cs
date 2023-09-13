using System;
using System.Collections;
using UnityEngine;

namespace ToonShooterPrototype.Infrastructure.Services
{
    public static class CoroutineRunnerExtensions
    {
        public static Coroutine RunInvoke(this ICoroutineRunner runner, Action action,
            YieldInstruction instruction = default) => runner.Run(InvokeActionRoutine(action, instruction));

        public static Coroutine RunInvoke(this ICoroutineRunner runner, Action action, float secondsToInvoke) =>
            runner.RunInvoke(action, new WaitForSeconds(secondsToInvoke));

        public static IEnumerator InvokeActionRoutine(Action action, YieldInstruction instruction)
        {
            yield return instruction;
            action.Invoke();
        }
    }
}