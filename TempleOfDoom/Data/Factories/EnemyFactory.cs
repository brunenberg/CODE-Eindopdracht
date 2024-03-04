using GameLogic.Entities;

namespace Data.Factories {
    public static class EnemyFactory {
        public static Enemy Create(EnemyDTO dto, int id) {
            Enemy enemy;
            switch (dto.type) {
                case "horizontal":
                    enemy = new HorizontalEnemy();
                    break;
                case "vertical":
                    enemy = new VerticalEnemy();
                    break;
                default:
                    enemy = new Enemy();
                    break;
            }
            enemy.CurrentRoomId = id;
            enemy.Type = dto.type;
            enemy.X = dto.x;
            enemy.Y = dto.y;
            enemy.MinX = dto.minX;
            enemy.MinY = dto.minY;
            enemy.MaxX = dto.maxX;
            enemy.MaxY = dto.maxY;
            enemy.Lives = 3;

            return enemy;
        }
    }
}
