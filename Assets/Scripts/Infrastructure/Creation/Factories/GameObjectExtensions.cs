﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ToonShooterPrototype.Infrastructure.Creation.Factories
{
    public static class GameObjectExtensions
    {
        public static TComponent AsInactive<TComponent>(this GameObject original,
            Func<GameObject, Transform, TComponent> instantiationFunc, Transform parent = default)
            where TComponent : Object
        {
            bool previousState = original.activeSelf;
            original.SetActive(false);
            TComponent component = instantiationFunc.Invoke(original, parent);
            original.SetActive(previousState);
            return component;
        }
    }
}