using GameLogic.Interfaces;
using System.Text.Json;

namespace Data.DataReaderStrategy
{
    public class JSONReader : IDataReader {
        public Level ReadData(string filePath) {
            string jsonString = File.ReadAllText(filePath);
            Level root = JsonSerializer.Deserialize<Level>(jsonString);
            return root;
        }
    }
}
