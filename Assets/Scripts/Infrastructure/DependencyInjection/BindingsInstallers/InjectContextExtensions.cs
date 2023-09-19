using System;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Infrastructure.DependencyInjection.BindingsInstallers
{
    public static class InjectContextExtensions
    {
        public static bool WhenInjectedInto<T>(this InjectContext context) => context.ObjectType == typeof(T);

        public static bool HasComponent<T>(this InjectContext context) =>
            context.ObjectInstance is Component component && component.TryGetComponent(out T _);

        public static bool HasComponent(this InjectContext context, Type type) =>
            context.ObjectInstance is Component component && component.TryGetComponent(type, out Component _);
    }
}