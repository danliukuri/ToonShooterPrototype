﻿using UnityEngine;

namespace ToonShooterPrototype.Data.Static.Configuration
{
    [CreateAssetMenu(fileName = nameof(PlayerCameraConfig), menuName = "Configuration/Player/Camera")]
    public class PlayerCameraConfig : ScriptableObject
    {
        [field: SerializeField, Min(default)] public float MaxViewDistance { get; private set; }
        [field: SerializeField] public string[] AttractiveObjectsTags { get; private set; }
    }
}