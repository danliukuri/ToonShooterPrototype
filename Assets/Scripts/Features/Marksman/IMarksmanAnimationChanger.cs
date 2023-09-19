using UnityEngine;

namespace ToonShooterPrototype.Features.Marksman
{
    public interface IMarksmanAnimationChanger
    {
        Animator Animator { get; set; }
        bool IsWalking { get; set; }
        bool IsRunning { get; set; }
        bool IsShooting { get; set; }
        float ShootingSpeed { get; set; }
        void Jump();
        void Death(int health = default);
    }
}