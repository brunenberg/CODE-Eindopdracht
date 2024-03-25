using Data;
using Data.DataReaderStrategy;
using Data.Factories;
using GameLogic.Models;

namespace UserInterface {
    internal class Program {
        private static string LevelPath = GetProjectRootPath("Data", "Levels", "TempleOfDoom_Extended_C_2223.json");

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

        private static string GetProjectRootPath(params string[] paths) {
            var projectPath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.Parent.FullName;
            return Path.Combine(projectPath, Path.Combine(paths));
        }
    }
}
