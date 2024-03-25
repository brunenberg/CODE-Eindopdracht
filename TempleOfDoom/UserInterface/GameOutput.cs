using GameLogic.Entities;
using GameLogic.Models;
using UserInterface.Views;

namespace UserInterface {
    public class GameOutput {
        private Root _root { get; set; }
        private string _currentLevel { get; set; }
        private MainView _mainView { get; set; }

        public GameOutput(Root root, string levelPath) {
            _root = root;
            _currentLevel = levelPath;
            _mainView = new MainView();
        }

        public void DisplayGameState() {
            StartMessage();
            DrawRoom();
            DisplayStats(_root.Player);
        }

        public void StartMessage() {
            Console.WriteLine("Welcome to the Temple Of Doom!");
            Console.WriteLine("Current level: " + _currentLevel);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
        }
        public void DrawRoom() {
            Room room = _root.Player.CurrentRoom;
            for (int y = 0; y < room.Height; y++) {
                for (int x = 0; x < room.Width; x++) {
                    List<GameObject> objects = room.GetObjectsAt(x, y);
                    if (objects.Count > 0) {
                        _mainView.PrintPriorityObject(objects);
                    } else {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }

        public void DisplayStats(Player player) {
            Console.WriteLine($"Lives: {player.Lives}");

            Console.Write("Inventory: ");
            for (int i = 0; i < player.Inventory.Count; i++) {
                var item = player.Inventory[i];
                ConsoleColor? color = PrintHelper.GetObjectColor(item, null);
                PrintHelper.PrintColoredString(item.Type, color);
                if (i < player.Inventory.Count - 1) {
                    Console.Write(", ");
                }
            }
            Console.WriteLine();
        }

        public void PrintLoseMessage() {
            Console.WriteLine("========================================================");
            Console.WriteLine("|     ____ ____ ____ ____      ____ ____ ____ ____     |");
            Console.WriteLine("|    ||G |||A |||M |||E ||    ||O |||V |||E |||R ||    |");
            Console.WriteLine("|    ||__|||__|||__|||__||    ||__|||__|||__|||__||    |");
            Console.WriteLine("|    |/__\\|/__\\|/__\\|/__\\|    |/__\\|/__\\|/__\\|/__\\|    |");
            Console.WriteLine("========================================================");
        }

        public void PrintWinMessage() {
            Console.WriteLine("|     _   _ _____ _   _      _ _ _ _ __    _   _     |");
            Console.WriteLine("|    | | | |  _  | | | |    | | | |_|  \\  | | | |    |");
            Console.WriteLine("|    | |_| | | | | | | |    | | | | |   \\ | | | |    |");
            Console.WriteLine("|    \\____ | | | | | | |    | | | | | |\\ \\| | |_|    |");
            Console.WriteLine("|     ___/ | |_| | |_| |    | | | | | | \\   |  _     |");
            Console.WriteLine("|    /____/\\_____/\\____/    \\_____|_|_|  \\__| |_|    |");


        }
    }
}
