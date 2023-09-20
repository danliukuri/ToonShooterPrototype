using System.Threading.Tasks;
using ToonShooterPrototype.Data.Dynamic;

namespace ToonShooterPrototype.Features.SaveSystem
{
    public interface IPlayerProgressSaver
    {
        Task Save(PlayerProgressData playerProgressData);
    }
}