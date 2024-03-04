using GameLogic.Decorators;
using GameLogic.Models;

namespace UserInterface.Views {
    public static class ConnectionView {
        private static Dictionary<Type, (char, ConsoleColor?)> characterMap = new Dictionary<Type, (char, ConsoleColor?)> {
            { typeof(SwitchDoor), ('~', ConsoleColor.DarkMagenta) },
            { typeof(Passage), (' ', null) }
        };

        public static DisplayInfo GetDisplayInfo(GameObject gameObject) {
            if (gameObject is Connection connection) {
                IDoor door = connection.Door;
                bool isDecorator = false;
                ConsoleColor? color = null;
                char character = (connection.North != null || connection.South != null) ? '=' : '|';

                while (door != null) {
                    if (door is ClosingGateDoor) {
                        character = 'n';
                        color = ConsoleColor.DarkGray;
                    } else if (characterMap.TryGetValue(door.GetType(), out var characterColor)) {
                        if (isDecorator && door is Passage) {
                            break;
                        }
                        if (door is Passage && !isDecorator) {
                            return new DisplayInfo(' ', null);
                        }
                        color = characterColor.Item2;
                    }
                    if (door is DoorDecorator decorator) {
                        isDecorator = true;
                        if (decorator is ColoredDoor coloredDoor) {
                            color = GetColorFromName(coloredDoor.Color);
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



        private static ConsoleColor? GetColorFromName(string colorName) {
            if (!string.IsNullOrEmpty(colorName)) {
                colorName = ToPascalCase(colorName);
                return (ConsoleColor)Enum.Parse(typeof(ConsoleColor), colorName);
            }
            return null;
        }

        private static string ToPascalCase(string str) {
            if (string.IsNullOrEmpty(str)) return str;
            return char.ToUpper(str[0]) + str.Substring(1).ToLower();
        }
    }
}
