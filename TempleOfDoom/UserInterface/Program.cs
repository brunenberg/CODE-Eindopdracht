using Data.DataReaderStrategy;
using Data;

namespace UserInterface {
    internal class Program {
        static void Main(string[] args) {
            JSONReader reader = new JSONReader();
            DataReaderContext context = new DataReaderContext(reader);
            string currentLevel = "../../../../Data/Levels/TempleOfDoom_Extended_C_2223.json";
            RootDTO rootDTO = context.ReadDataFromFile(currentLevel);

            Root root = RootFactory.Create(rootDTO);
        }
    }
}
