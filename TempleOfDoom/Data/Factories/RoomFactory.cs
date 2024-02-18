using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;

namespace Data.Factories {
    public static class RoomFactory {

        public static Room Create(RoomDTO dto) {
            Room room = new Room {
                Id = dto.id,
                Width = dto.width,
                Height = dto.height,
                Items = dto.items != null ? dto.items.Select(itemDto => ItemFactory.Create(itemDto)).ToList() : new List<Item>(),
                Enemies = dto.enemies != null ? dto.enemies.Select(enemyDto => EnemyFactory.Create(enemyDto)).ToList() : new List<Enemy>()
            };
            return room;
        }
    }
}
