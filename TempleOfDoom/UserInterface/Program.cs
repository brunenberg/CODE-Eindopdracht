using Data;
using Data.DataReaderStrategy;
using Data.Factories;
using GameLogic.Models;

namespace UserInterface {
    internal class Program {
        static void Main(string[] args) {
            IDataReader reader = new JSONReader();
            DataReaderContext context = new DataReaderContext(reader);
            string levelPath = "Data/Levels/TempleOfDoom_Extended_C_2223.json";
            RootDTO rootDTO = context.ReadDataFromFile(levelPath);

            RootFactory rootFactory = new RootFactory();

            Root root = rootFactory.Create(rootDTO);

            new GameEngine(root, levelPath).Run();
        }
    }
}
