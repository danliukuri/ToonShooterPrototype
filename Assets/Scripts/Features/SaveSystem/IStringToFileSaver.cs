using System.Threading.Tasks;

namespace ToonShooterPrototype.Features.SaveSystem
{
    public interface IStringToFileSaver
    {
        bool DoesTheFileExist(string filename);
        Task SaveStringToFile(string data, string filename);
        Task<string> LoadStringFromFile(string filename);
    }
}