using Data;
using Data.DataReaderStrategy;
using Data.Factories;
using GameLogic.Models;

namespace UserInterface {
    internal class Program {
        private const string LevelPath = "Data/Levels/TempleOfDoom_Extended_C_2223.json";

        public GameEngine GameEngine {
            get => default;
            set {
            }
        }

        static void Main(string[] args) {
            Root root = LoadRootFromData();
            new GameEngine(root, LevelPath).Run();
        }

        private static Root LoadRootFromData() {
            IDataReader reader = new JSONReader();
            DataReaderContext context = new DataReaderContext(reader);
            RootDTO rootDTO = context.ReadDataFromFile(LevelPath);

            RootFactory rootFactory = new RootFactory();
            return rootFactory.Create(rootDTO);
        }
    }
}
