﻿using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(PlayerConfig), menuName = "Configuration/Player")]
    public class PlayerConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public float MoveSpeed { get; private set; }
    }
}