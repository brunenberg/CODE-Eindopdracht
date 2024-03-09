using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;
using GameLogic.Tiles;

namespace Data.Factories {
    public class RoomFactory {
        private ItemFactory _itemFactory;
        private EnemyFactory _enemyFactory;

        public RoomFactory() {
            _itemFactory = new ItemFactory();
            _enemyFactory = new EnemyFactory();
        }

        public Room Create(RoomDTO dto, List<Connection> connections, Player player, int startRoomId) {
            int height = dto.height;
            int width = dto.width;

            Room room = new Room {
                Id = dto.id,
                Width = width,
                Height = height
            };

            if (dto.items != null) {
                foreach (ItemDTO itemDto in dto.items) {
                    Item item = _itemFactory.Create(itemDto, room);
                    room.AddObject(item);
                }
            }

            if (dto.enemies != null) {
                foreach (EnemyDTO enemyDto in dto.enemies) {
                    EnemyAdapter enemy = _enemyFactory.Create(enemyDto);
                    room.AddObject(enemy);
                }
            }

            if (player != null && room.Id == startRoomId) {
                room.AddObject(player);
                player.CurrentRoom = room;
            }

            for (int y = 0; y < height; y++) {
                for (int x = 0; x < width; x++) {
                    if (y == 0 || y == height - 1 || x == 0 || x == width - 1) {
                        bool isDoor = false;
                        if (connections != null) {
                            foreach (Connection connection in connections) {
                                if (IsConnectionLocation(x, y, room, connection)) {
                                    room.AddObjectOnLocation(connection, x, y);
                                    isDoor = true;
                                    break;
                                }
                            }
                        }
                        if (!isDoor) {
                            Wall wall = new Wall();
                            wall.X = x;
                            wall.Y = y;
                            room.AddObject(wall);
                        }
                    }
                }
            }

            return room;
        }

        private bool IsConnectionLocation(int x, int y, Room room, Connection connection) {
            int middleY = room.Height / 2;
            int middleX = room.Width / 2;

            if ((connection.North == room.Id || connection.South == room.Id) && y == (connection.North == room.Id ? room.Height - 1 : 0) && x == middleX) {
                return true;
            }

            if ((connection.East == room.Id || connection.West == room.Id) && x == (connection.East == room.Id ? 0 : room.Width - 1) && y == middleY) {
                return true;
            }

            return false;
        }

    }
}
