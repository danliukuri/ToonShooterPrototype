using System;
using UnityEngine;

namespace ToonShooterPrototype.Data.Dynamic
{
    [Serializable]
    public class PlayerProgressData
    {
        [field: SerializeField] public int WinCount { get; set; }
        [field: SerializeField] public int LoseCount { get; set; }
    }
}