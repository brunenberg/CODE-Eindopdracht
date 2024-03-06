using GameLogic.Models;

namespace UserInterface {
    public enum Action {
        MOVE_NORTH,
        MOVE_SOUTH,
        MOVE_EAST,
        MOVE_WEST
    }

    public class GameInput {
        private Root Root { get; set; }
        private GameOutput GameOutput { get; set; }

        private Dictionary<ConsoleKey, Action> keyToActionMap = new Dictionary<ConsoleKey, Action> {
            { ConsoleKey.W, Action.MOVE_NORTH },
            { ConsoleKey.UpArrow, Action.MOVE_NORTH },
            { ConsoleKey.A, Action.MOVE_WEST },
            { ConsoleKey.LeftArrow, Action.MOVE_WEST },
            { ConsoleKey.D, Action.MOVE_EAST },
            { ConsoleKey.RightArrow, Action.MOVE_EAST },
            { ConsoleKey.S, Action.MOVE_SOUTH },
            { ConsoleKey.DownArrow, Action.MOVE_SOUTH }
        };

        public GameInput(Root root, GameOutput gameOutput) {
            this.Root = root;
            this.GameOutput = gameOutput;
        }

        public bool ProcessInput() {
            ConsoleKeyInfo keyInfo = GetKeyPress();
            return HandleKeyPress(keyInfo);
        }

        private ConsoleKeyInfo GetKeyPress() {
            return Console.ReadKey(intercept: true);
        }

        private bool HandleKeyPress(ConsoleKeyInfo keyInfo) {
            bool shouldUpdateGameState = false;
            if (keyToActionMap.TryGetValue(keyInfo.Key, out Action action)) {
                switch (action) {
                    case Action.MOVE_NORTH:
                    case Action.MOVE_SOUTH:
                    case Action.MOVE_EAST:
                    case Action.MOVE_WEST:
                        Direction direction = (Direction)Enum.Parse(typeof(Direction), action.ToString().Split('_')[1]);
                        shouldUpdateGameState = Root.Player.Move(Root, direction);
                        break;
                }
            }
            return shouldUpdateGameState;
        }
    }
}
