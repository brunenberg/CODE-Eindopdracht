using GameLogic.Decorators;
using GameLogic.Models;

namespace UserInterface.Views {
    public static class DoorView {
        private static Dictionary<Type, (char, ConsoleColor?)> characterMap = new Dictionary<Type, (char, ConsoleColor?)> {
            { typeof(ClosingGateDoor), ('n', ConsoleColor.DarkGray) },
            { typeof(SwitchDoor), ('P', ConsoleColor.DarkMagenta) },
            { typeof(Passage), (' ', null) }
        };

        public static DisplayInfo GetDisplayInfo(GameObject door) {
            if (characterMap.TryGetValue(door.GetType(), out var characterColor)) {
                return new DisplayInfo(characterColor.Item1, characterColor.Item2);
            }
            throw new ArgumentException($"Door of type '{door.GetType()}' is not recognized");
        }
    }
}
