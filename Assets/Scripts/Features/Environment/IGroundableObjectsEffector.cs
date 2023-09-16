using System.Collections.Generic;
using ToonShooterPrototype.Data.Dynamic;

namespace ToonShooterPrototype.Features.Environment
{
    public interface IGroundableObjectsEffector
    {
        IList<IGroundable> GroundableObjects { get; set; }
    }
}