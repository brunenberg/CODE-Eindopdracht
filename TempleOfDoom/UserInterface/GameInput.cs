using GameLogic.Models;

namespace UserInterface {
    public class GameInput {
        private Root Root { get; set; }
        private GameOutput GameOutput { get; set; }

        private Dictionary<ConsoleKey, Direction> keyToDirectionMap = new Dictionary<ConsoleKey, Direction> {
            { ConsoleKey.W, Direction.NORTH },
            { ConsoleKey.UpArrow, Direction.NORTH },
            { ConsoleKey.A, Direction.WEST },
            { ConsoleKey.LeftArrow, Direction.WEST },
            { ConsoleKey.D, Direction.EAST },
            { ConsoleKey.RightArrow, Direction.EAST },
            { ConsoleKey.S, Direction.SOUTH },
            { ConsoleKey.DownArrow, Direction.SOUTH }
        };

        public GameInput(Root root, GameOutput gameOutput) {
            this.Root = root;
            this.GameOutput = gameOutput;
        }

        public void ProcessInput() {
            ConsoleKeyInfo keyInfo = GetKeyPress();
            HandleKeyPress(keyInfo);
        }

        private ConsoleKeyInfo GetKeyPress() {
            return Console.ReadKey(intercept: true);
        }

        private void HandleKeyPress(ConsoleKeyInfo keyInfo) {
            if (keyToDirectionMap.TryGetValue(keyInfo.Key, out Direction direction)) {
                Root.Player.Move(Root, direction);
            }
        }
    }
}
