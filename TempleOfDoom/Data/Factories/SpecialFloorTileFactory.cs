using GameLogic.Models;
using GameLogic.Tiles;

namespace Data.Factories {
    public class SpecialFloorTileFactory {
        private readonly Dictionary<string, Func<SpecialFloorTileDTO, Room, List<Connection>, GameObject>> specialFloorTileCreators;

        public SpecialFloorTileFactory() {
            specialFloorTileCreators = new Dictionary<string, Func<SpecialFloorTileDTO, Room, List<Connection>, GameObject>> {
                { "wall", (dto, room, connections) => new Wall { X = dto.x, Y = dto.y } },
                { "innerdoor", CreateInnerDoor }
            };
        }

        private GameObject CreateInnerDoor(SpecialFloorTileDTO dto, Room room, List<Connection> connections) {
            Connection connection = connections.FirstOrDefault(c => c.Within == room.Id);
            connection.X = dto.x;
            connection.Y = dto.y;
            if (connection == null) {
                throw new ArgumentException($"No connection found with Within value '{room.Id}'");
            }
            room.AddObjectOnLocation(connection, dto.x, dto.y);
            return connection;
        }

        public GameObject Create(SpecialFloorTileDTO dto, Room room, List<Connection> connections) {
            if (specialFloorTileCreators.TryGetValue(dto.type, out Func<SpecialFloorTileDTO, Room, List<Connection>, GameObject> createSpecialFloorTile)) {
                return createSpecialFloorTile(dto, room, connections);
            } else {
                throw new ArgumentException($"Item of type '{dto.type}' is not recognized");
            }
        }
    }
}
