using GameLogic.Models;

namespace UserInterface {
    public enum Action {
        MOVE_NORTH,
        MOVE_SOUTH,
        MOVE_EAST,
        MOVE_WEST,
        SHOOT
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
            { ConsoleKey.DownArrow, Action.MOVE_SOUTH },
            { ConsoleKey.Spacebar, Action.SHOOT }
        };

        private Dictionary<Action, Func<bool>> actionToFunctionMap;

        public GameInput(Root root, GameOutput gameOutput) {
            this.Root = root;
            this.GameOutput = gameOutput;

            actionToFunctionMap = new Dictionary<Action, Func<bool>> {
                { Action.MOVE_NORTH, () => Root.Player.Move(Root, Direction.NORTH) },
                { Action.MOVE_SOUTH, () => Root.Player.Move(Root, Direction.SOUTH) },
                { Action.MOVE_EAST, () => Root.Player.Move(Root, Direction.EAST) },
                { Action.MOVE_WEST, () => Root.Player.Move(Root, Direction.WEST) },
                { Action.SHOOT, () => Root.Player.Shoot(Root) }
            };
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
                if (actionToFunctionMap.TryGetValue(action, out Func<bool> actionFunction)) {
                    shouldUpdateGameState = actionFunction();
                }
            }
            return shouldUpdateGameState;
        }
    }
}
