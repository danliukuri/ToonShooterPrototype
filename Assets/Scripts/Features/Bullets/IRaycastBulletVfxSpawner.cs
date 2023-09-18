using UnityEngine;

namespace ToonShooterPrototype.Features.Bullets
{
    public interface IRaycastBulletVfxSpawner
    {
        void Spawn(RaycastHit hit);
    }
}