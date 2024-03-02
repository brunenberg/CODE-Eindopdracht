using GameLogic.Entities;
using GameLogic.Models;
using UserInterface.Observers;

namespace UserInterface {
    public class GameOutput {
        public Root Root { get; set; }
        public string CurrentLevel { get; set; }
        public DisplayElement PlayerStatsDisplay { get; set; }

        public GameOutput(Root root, string levelPath) {
            Root = root;
            CurrentLevel = levelPath;
            PlayerStatsDisplay = new DisplayElement();
        }

        public void DisplayGameState() {
            StartMessage();
            DrawRoom();
            PlayerStatsDisplay.OnNext(Root.Player);
        }

        public void StartMessage() {
            Console.WriteLine("Welcome to the Temple Of Doom!");
            Console.WriteLine("Current level: " + CurrentLevel);
            Console.WriteLine("--------------------------------------------------------------------");
            Console.WriteLine("--------------------------------------------------------------------");
        }
        public void DrawRoom() {
            Room room = Root.Rooms.Find(r => r.Id == Root.Player.CurrentRoomId);
            for (int y = 0; y < room.Height; y++) {
                for (int x = 0; x < room.Width; x++) {
                    List<GameObject> objects = room.GetObjectsAt(x, y);
                    if (objects.Count > 0) {
                        PrintHelper.PrintPriorityObject(objects);
                    } else {
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
