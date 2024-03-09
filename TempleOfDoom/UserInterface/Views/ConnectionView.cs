using GameLogic.Decorators;
using GameLogic.Models;

namespace UserInterface.Views {
    public class ConnectionView {
        public DisplayInfo GetDisplayInfo(GameObject gameObject) {
            if (gameObject is Connection connection) {
                IDoor door = connection.Door;
                bool isDecorator = false;
                ConsoleColor? color = null;
                char character = (connection.North != null || connection.South != null) ? '=' : '|';

                while (door != null) {
                    if (door is ClosingGateDoor) {
                        character = 'n';
                        color = ConsoleColor.DarkGray;
                    } else if (door is SwitchDoor) {
                        character = '~';
                        color = ConsoleColor.DarkMagenta;
                    } else if (door is Passage) {
                        if (isDecorator) {
                            break;
                        } else {
                            return new DisplayInfo(' ', null);
                        }
                    }
                    if (door is DoorDecorator decorator) {
                        isDecorator = true;
                        if (decorator is ColoredDoor coloredDoor) {
                            color = PrintHelper.GetColorFromString(coloredDoor.Color);
                        }
                        door = decorator.GetUnderlyingDoor();
                    } else {
                        break;
                    }
                }
                return new DisplayInfo(character, color);
            }
            throw new ArgumentException($"Object of type '{gameObject.GetType()}' is not recognized or does not have a recognized door type");
        }

    }
}
