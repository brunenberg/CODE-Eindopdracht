
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
            GameOutput.DisplayGameState();
            while (true) {
                if (GameInput.ProcessInput()) {
                    Console.Clear();
                    GameOutput.DisplayGameState();
                }


                // if (gameIsOver) {
                //     break;
                // }
            }
        }
    }

}
