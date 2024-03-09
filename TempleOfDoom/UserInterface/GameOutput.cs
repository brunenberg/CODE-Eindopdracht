using GameLogic.Models;
using UserInterface.Observers;
using UserInterface.Views;

namespace UserInterface {
    public class GameOutput {
        private Root _root { get; set; }
        private string _currentLevel { get; set; }
        private MainView _mainView { get; set; }
        private PlayerStatsDisplayElement _playerStatsDisplay { get; set; }

        public GameOutput(Root root, string levelPath) {
            _root = root;
            _currentLevel = levelPath;
            _mainView = new MainView();
            _playerStatsDisplay = new PlayerStatsDisplayElement();
        }

        public void DisplayGameState() {
            StartMessage();
            DrawRoom();
            _playerStatsDisplay.OnNext(_root.Player);
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
    }
}
