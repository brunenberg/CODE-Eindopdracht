using Data.DataReaderStrategy;
using Data;
using Data.Factories;
using GameLogic.Models;

namespace UserInterface {
    internal class Program {
        static void Main(string[] args) {
            IDataReader reader = new JSONReader();
            DataReaderContext context = new DataReaderContext(reader);
            string currentLevel = "../../../../Data/TempleOfDoom_Extended_C_2223.json";
            RootDTO rootDTO = context.ReadDataFromFile(currentLevel);

            Root root = RootFactory.Create(rootDTO);
        }
    }
}
