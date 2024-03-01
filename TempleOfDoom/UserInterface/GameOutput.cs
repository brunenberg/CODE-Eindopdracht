using GameLogic.Entities;
using GameLogic.Models;

namespace UserInterface {
    public class GameOutput {
        public Root Root { get; set; }
        public string CurrentLevel { get; set; }

        public GameOutput(Root root, string levelPath) {
            Root = root;
            CurrentLevel = levelPath;
        }

        public void StartMessage() {
            Console.WriteLine("Welcome to the Temple Of Doom!");
            Console.WriteLine("Current level: " + CurrentLevel);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
        }

        public void DisplayGameState() {

        }
    }
}
