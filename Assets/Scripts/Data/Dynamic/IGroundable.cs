using UnityEngine;

namespace ToonShooterPrototype.Data.Dynamic
{
    public interface IGroundable
    {
        bool IsGrounded { get; set; }
        ref Vector3 JumpingForce { get; }
    }
}