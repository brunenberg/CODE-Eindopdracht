
using GameLogic.Items;
using GameLogic.Models;

namespace UserInterface {
    public class GameEngine {
        private Root Root { get; set; }
        private GameOutput GameOutput { get; set; }
        private GameInput GameInput { get; set; }

        public GameEngine(Root root, string levelPath) {
            Root = root;
            GameOutput = new(root, levelPath);
            GameInput = new(root, GameOutput);
        }

        public void Run() {
            bool gameIsRunning = true;

            GameOutput.DisplayGameState();

            while (gameIsRunning) {
                bool shouldUpdateGameState = GameInput.ProcessInput();
                if (shouldUpdateGameState) {
                    Root.Player.InteractWithCurrentLocation(Root, Root.Player);
                    Console.Clear();
                    GameOutput.DisplayGameState();
                }
                gameIsRunning = CheckGameStatus();
            }
        }

        private bool CheckGameStatus() {
            int sankaraStoneAmount = Root.Player.Inventory.Count(item => item is SankaraStone);
            if (sankaraStoneAmount >= 5) {
                GameOutput.PrintWinMessage();
                return false;
            }
            if (Root.Player.Lives <= 0) {
                GameOutput.PrintLoseMessage();
                return false;
            }
            return true;
        }

    }
}
