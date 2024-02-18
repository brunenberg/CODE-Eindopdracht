using Data.DataReaderStrategy;
using Data;

namespace UserInterface {
    internal class Program {
        static void Main(string[] args) {
            JSONReader reader = new();
            string currentLevel = "../../../../Data/TempleOfDoom_Extended_C_2223.json";
            Level level = reader.ReadData(currentLevel);
        }
    }
}