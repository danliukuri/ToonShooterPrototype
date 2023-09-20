using System.Threading.Tasks;
using ToonShooterPrototype.Data.Dynamic;
using UnityEngine;

namespace ToonShooterPrototype.Features.SaveSystem
{
    public class PlayerProgressSaver : IPlayerProgressSaver, IPlayerProgressLoader
    {
        private const string PlayerProgressFilename = "PlayerProgress";

        private readonly IStringToFileSaver _stringToFileSaver;

        public PlayerProgressSaver(IStringToFileSaver stringToFileSaver) => _stringToFileSaver = stringToFileSaver;

        public Task Save(PlayerProgressData playerProgressData) =>
            _stringToFileSaver.SaveStringToFile(JsonUtility.ToJson(playerProgressData), PlayerProgressFilename);
        
        public async Task<PlayerProgressData> Load(PlayerProgressData playerProgressData)
        {
            if (_stringToFileSaver.DoesTheFileExist(PlayerProgressFilename))
            {
                Task<string> loadStringFromFile = _stringToFileSaver.LoadStringFromFile(PlayerProgressFilename);
                await loadStringFromFile;
                if (loadStringFromFile.IsCompletedSuccessfully)
                    JsonUtility.FromJsonOverwrite(loadStringFromFile.Result, playerProgressData);
            }
            return playerProgressData;
        }
    }
}