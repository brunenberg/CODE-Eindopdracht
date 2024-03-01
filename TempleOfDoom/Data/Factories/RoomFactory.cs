using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;
using GameLogic.Tiles;

namespace Data.Factories {
    public static class RoomFactory {

        public static Room Create(RoomDTO dto) {
            int height = dto.height;
            int width = dto.width;

            Room room = new Room {
                Id = dto.id,
                Width = width,
                Height = height
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

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    if (y == 0 || y == height - 1 || x == 0 || x == width - 1) {
                        Wall wall = new Wall();
                        wall.X = x;
                        wall.Y = y;
                        room.AddObject(wall);
                    }
                }
            }

            return room;
        }
    }
}
