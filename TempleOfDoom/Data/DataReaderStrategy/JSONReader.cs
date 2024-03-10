using System.Text.Json;

namespace Data.DataReaderStrategy {
    public class JSONReader : IDataReader {

        public RootDTO ReadData(string filePath) {
            string jsonString = File.ReadAllText(filePath);
            RootDTO root = JsonSerializer.Deserialize<RootDTO>(jsonString);
            return root;
        }
    }
}
