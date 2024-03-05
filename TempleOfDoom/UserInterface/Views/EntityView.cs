
using GameLogic.Entities;
using GameLogic.Models;

namespace UserInterface.Views {
    public static class EntityView {
        private static Dictionary<Type, (char, ConsoleColor?)> characterMap = new Dictionary<Type, (char, ConsoleColor?)> {
            { typeof(Player), ('X', ConsoleColor.White) },
            { typeof(EnemyAdapter), ('E', ConsoleColor.Blue) }
        };

        public static DisplayInfo GetDisplayInfo(GameObject entity) {
            Type entityType = entity.GetType();
            if (entityType == typeof(HorizontalEnemy) || entityType == typeof(VerticalEnemy)) {
                entityType = typeof(Enemy);
            }

            if (characterMap.TryGetValue(entityType, out var characterColor)) {
                return new DisplayInfo(characterColor.Item1, characterColor.Item2);
            }
            throw new ArgumentException($"Entity of type '{entity.GetType()}' is not recognized");
        }
    }
}
