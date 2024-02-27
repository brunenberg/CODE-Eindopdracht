using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;
using GameLogic.Tiles;

namespace Data.Factories {
    public static class RoomFactory {

        public static Room Create(RoomDTO dto) {
            Room room = new Room {
                Id = dto.id,
                Width = dto.width,
                Height = dto.height
            };

            if (dto.items != null) {
                foreach (ItemDTO itemDto in dto.items) {
                    Item item = ItemFactory.Create(itemDto);
                    room.AddObject(item);
                }
            }

            if (dto.enemies != null) {
                foreach (EnemyDTO enemyDto in dto.enemies) {
                    Enemy enemy = EnemyFactory.Create(enemyDto);
                    room.AddObject(enemy);
                }
            }

            if (dto.specialFloorTiles != null) {
                foreach (SpecialFloorTileDTO specialFloorTileDto in dto.specialFloorTiles) {
                    GameObject specialFloorTile = SpecialFloorTileFactory.Create(specialFloorTileDto);
                    room.AddObject(specialFloorTile);
                }
            }

            return room;
        }
    }
}
