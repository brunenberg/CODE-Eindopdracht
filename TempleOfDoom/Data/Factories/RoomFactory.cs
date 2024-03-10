using GameLogic.Decorators;
using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Models;
using GameLogic.Tiles;

namespace Data.Factories {
    public class RoomFactory {
        private ItemFactory _itemFactory;
        private EnemyFactory _enemyFactory;
        private SpecialFloorTileFactory _specialFloorTileFactory;

        public RoomFactory() {
            _itemFactory = new ItemFactory();
            _enemyFactory = new EnemyFactory();
            _specialFloorTileFactory = new SpecialFloorTileFactory();
        }

        public Room Create(RoomDTO dto, List<Connection> connections, Player player, int startRoomId) {
            int height = dto.height;
            int width = dto.width;

            Room room = new Room {
                Id = dto.id,
                Width = width,
                Height = height
            };

            List<PressurePlate> pressurePlates = new List<PressurePlate>();
            List<ToggleDoor> toggleDoors = new List<ToggleDoor>();

            if (dto.items != null) {
                foreach (ItemDTO itemDto in dto.items) {
                    Item item = _itemFactory.Create(itemDto, room);
                    room.AddObject(item);

                    if (item is PressurePlate pressurePlate) {
                        pressurePlates.Add(pressurePlate);
                    }
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
                                if (IsConnectionLocation(x, y, room, connection, toggleDoors)) {
                                    room.AddObjectOnLocation(connection, x, y);
                                    isDoor = true;
                                    break;
                                }
                            }
                        }
                        if (!isDoor) {
                            Wall wall = new Wall { X = x, Y = y};
                            room.AddObject(wall);
                        }
                    }
                }
            }

            if (dto.specialFloorTiles != null) {
                foreach (SpecialFloorTileDTO specialFloorTileDto in dto.specialFloorTiles) {
                    GameObject specialFloorTile = _specialFloorTileFactory.Create(specialFloorTileDto, room, connections);
                    room.AddObject(specialFloorTile);
                }
            }

            foreach (PressurePlate pressurePlate in pressurePlates) {
                foreach (ToggleDoor toggleDoor in toggleDoors) {
                    pressurePlate.RegisterObserver(toggleDoor);
                }
            }

            return room;
        }

        private bool IsConnectionLocation(int x, int y, Room room, Connection connection, List<ToggleDoor> toggleDoors) {
            int middleY = room.Height / 2;
            int middleX = room.Width / 2;

            if ((connection.North == room.Id || connection.South == room.Id) && y == (connection.North == room.Id ? room.Height - 1 : 0) && x == middleX) {
                AddDoorToToggleDoorsList(room, connection, x, y, toggleDoors);
                return true;
            }

            if ((connection.East == room.Id || connection.West == room.Id) && x == (connection.East == room.Id ? 0 : room.Width - 1) && y == middleY) {
                AddDoorToToggleDoorsList(room, connection, x, y, toggleDoors);
                return true;
            }

            return false;
        }

        private void AddDoorToToggleDoorsList(Room room, Connection connection, int x, int y, List<ToggleDoor> toggleDoors) {
            IDoor door = connection.Door;
            if (door is ToggleDoor toggleDoor) {
                toggleDoors.Add(toggleDoor);
            }
        }
    }
}
