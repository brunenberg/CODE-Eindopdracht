using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;
using GameLogic.Tiles;

namespace Data.Factories {
    public static class RoomFactory {

        public static Room Create(RoomDTO dto, List<Connection> connections, Player player = null) {
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
                    EnemyAdapter enemy = EnemyFactory.Create(enemyDto);
                    room.AddObject(enemy);
                }
            }

            if (player != null && room.Id == player.CurrentRoomId) {
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

        private static bool IsConnectionLocation(int x, int y, Room room, Connection connection) {
            int middleY = room.Height / 2;
            int middleX = room.Width / 2;

            if (connection.North == room.Id && y == room.Height - 1 && x == middleX) {
                return true;
            } else if (connection.South == room.Id && y == 0 && x == middleX) {
                return true;
            }

            if (connection.East == room.Id && x == 0 && y == middleY) {
                return true;
            } else if (connection.West == room.Id && x == room.Width - 1 && y == middleY) {
                return true;
            }

            return false;
        }
    }
}
