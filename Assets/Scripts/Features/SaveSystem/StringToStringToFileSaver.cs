using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;

namespace ToonShooterPrototype.Features.SaveSystem
{
    public class StringToStringToFileSaver : IStringToFileSaver
    {
        private const string FolderNameForSavingFiles = "SavedData";

        private static readonly string _directoryForSavingFiles =
            Application.persistentDataPath + '/' + FolderNameForSavingFiles + '/';

        public bool DoesTheFileExist(string filename) => File.Exists(_directoryForSavingFiles + filename);
        public Task SaveStringToFile(string data, string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("File name cannot be null or whitespace.", nameof(filename));

            if (!Directory.Exists(_directoryForSavingFiles))
                Directory.CreateDirectory(_directoryForSavingFiles);
            return File.WriteAllTextAsync(_directoryForSavingFiles + filename, data);
        }
        public Task<string> LoadStringFromFile(string filename)
        {
            if (string.IsNullOrWhiteSpace(filename))
                throw new ArgumentException("File name cannot be null or whitespace.", nameof(filename));

            string fullPath = _directoryForSavingFiles + filename;
            if (!File.Exists(fullPath))
                throw new ArgumentException($"'{filename}' does not exist by the path: {fullPath}", nameof(filename));
            return File.ReadAllTextAsync(fullPath);
        }
    }
}