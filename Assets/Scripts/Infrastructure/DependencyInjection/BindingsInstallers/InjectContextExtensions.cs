using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers
{
    public static class InjectContextExtensions
    {
        public static bool WhenInjectedInto<T>(this InjectContext context) => context.ObjectType == typeof(T);

        public static bool HasComponent<T>(this InjectContext context) =>
            context.ObjectInstance is Component component && component.TryGetComponent(out T _);
    }
}