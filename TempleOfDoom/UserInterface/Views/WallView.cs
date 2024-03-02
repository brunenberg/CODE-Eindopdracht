using GameLogic.Models;
using GameLogic.Tiles;

namespace UserInterface.Views {
    public static class WallView {
        private static Dictionary<Type, (char, ConsoleColor?)> characterMap = new Dictionary<Type, (char, ConsoleColor?)> {
            { typeof(Wall), ('#', ConsoleColor.Yellow) }
        };

        public static DisplayInfo GetDisplayInfo(GameObject wall) {
            if (characterMap.TryGetValue(wall.GetType(), out var characterColor)) {
                return new DisplayInfo(characterColor.Item1, characterColor.Item2);
            }
            throw new ArgumentException($"Wall of type '{wall.GetType()}' is not recognized");
        }
    }
}
