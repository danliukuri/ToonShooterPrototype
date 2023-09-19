using UnityEngine;

namespace ToonShooterPrototype.Features.Marksman
{
    public class MarksmanAnimationChanger : IMarksmanAnimationChanger
    {
        public Animator Animator { get; set; }

        public bool IsWalking
        {
            get => Animator.GetBool(nameof(IsWalking));
            set => Animator.SetBool(nameof(IsWalking), value);
        }

        public bool IsRunning
        {
            get => Animator.GetBool(nameof(IsRunning));
            set => Animator.SetBool(nameof(IsRunning), value);
        }

        public bool IsShooting
        {
            get => Animator.GetBool(nameof(IsShooting));
            set => Animator.SetBool(nameof(IsShooting), value);
        }

        public float ShootingSpeed
        {
            get => Animator.GetFloat(nameof(ShootingSpeed));
            set => Animator.SetFloat(nameof(ShootingSpeed), value);
        }

        public void Jump() => Animator.SetTrigger(nameof(Jump));

        public void Death() => Animator.SetTrigger(nameof(Death));
    }
}