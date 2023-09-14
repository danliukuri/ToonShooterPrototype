using ToonShooterPrototype.Data.Static.Configuration;
using UnityEngine;

namespace ToonShooterPrototype.Data.Dynamic
{
    public class PlayerData
    {
        public Transform Transform { get; set; }
        public CharacterController CharacterController { get; set; }
        
        public PlayerConfig Config { get; set; }
    }
}