using GameLogic.Entities;
using GameLogic.Models;

namespace UserInterface.Views {
    public class EntityView {
        private readonly Dictionary<Type, (char, ConsoleColor?)> characterMap = new Dictionary<Type, (char, ConsoleColor?)> {
            { typeof(Player), ('X', ConsoleColor.White) },
            { typeof(EnemyAdapter), ('E', ConsoleColor.Blue) }
        };

        public DisplayInfo GetDisplayInfo(GameObject entity) {
            Type entityType = entity.GetType();

            if (characterMap.TryGetValue(entityType, out var characterColor)) {
                return new DisplayInfo(characterColor.Item1, characterColor.Item2);
            }
            throw new ArgumentException($"Entity of type '{entity.GetType()}' is not recognized");
        }
    }
}
