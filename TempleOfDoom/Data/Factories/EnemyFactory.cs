using GameLogic.Entities;

namespace Data.Factories {
    public static class EnemyFactory {
        public static Enemy Create(EnemyDTO dto) {
            Enemy enemy = new Enemy {
                Type = dto.type,
                X = dto.x,
                Y = dto.y,
                MinX = dto.minX,
                MinY = dto.minY,
                MaxX = dto.maxX,
                MaxY = dto.maxY
            };
            return enemy;
        }
    }
}
