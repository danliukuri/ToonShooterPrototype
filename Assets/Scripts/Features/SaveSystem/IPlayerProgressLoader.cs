using System.Threading.Tasks;
using ToonShooterPrototype.Data.Dynamic;

namespace ToonShooterPrototype.Features.SaveSystem
{
    public interface IPlayerProgressLoader
    {
        Task<PlayerProgressData> Load(PlayerProgressData playerProgressData);
    }
}