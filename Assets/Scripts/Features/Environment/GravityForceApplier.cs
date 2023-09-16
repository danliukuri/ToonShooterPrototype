using System.Collections.Generic;
using ToonShooterPrototype.Data.Dynamic;
using ToonShooterPrototype.Data.Static.Configuration;
using UnityEngine;
using Zenject;

namespace ToonShooterPrototype.Features.Environment
{
    public class GravityForceApplier : ITickable, IGroundableObjectsEffector
    {
        private readonly EnvironmentConfig _environmentConfig;

        public IList<IGroundable> GroundableObjects { get; set; } = new List<IGroundable>();

        public GravityForceApplier(EnvironmentConfig environmentConfig) => _environmentConfig = environmentConfig;

        public void Tick()
        {
            for (var i = 0; i < GroundableObjects.Count; i++)
            {
                IGroundable obj = GroundableObjects[i];
                if (!obj.IsGrounded)
                    ApplyGravity(obj, Time.deltaTime);
                else
                    ApplyStickingForce(obj);
            }
        }

        private void ApplyGravity(IGroundable obj, float deltaTime) =>
            obj.JumpingForce.y += 2f * _environmentConfig.GravityForce * deltaTime;

        private void ApplyStickingForce(IGroundable obj) => obj.JumpingForce.y = _environmentConfig.StickingForce;
    }
}