using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab5.Interfaces;
using System.Threading.Tasks;

namespace lab5.Classes
{
    public class JsonFileWriter : IFileSaver
    {
        public async Task SaveAsync<T>(string filePath, List<T> data)
        {
            string? directoryPath = Path.GetDirectoryName(filePath);
            if (directoryPath != null && !Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var json = System.Text.Json.JsonSerializer.Serialize(data, new System.Text.Json.JsonSerializerOptions{ WriteIndented = true });
            await File.WriteAllLinesAsync(filePath, json);
        }
    }
}
