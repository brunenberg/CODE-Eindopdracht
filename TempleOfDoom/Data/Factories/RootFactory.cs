using GameLogic.Entities;
using GameLogic.Models;

namespace Data.Factories {
    public class RootFactory {
        private PlayerFactory _playerFactory;
        private ConnectionFactory _connectionFactory;
        private RoomFactory _roomFactory;

        public RootFactory() {
            _playerFactory = new PlayerFactory();
            _connectionFactory = new ConnectionFactory();
            _roomFactory = new RoomFactory();
        }

        public Root Create(RootDTO dto) {
            Player player = CreatePlayer(dto);
            List<Connection> connections = CreateConnections(dto);
            List<Room> rooms = CreateRooms(dto, connections, player);

            return new Root {
                Rooms = rooms,
                Connections = connections,
                Player = player
            };
        }

        private Player CreatePlayer(RootDTO dto) {
            return _playerFactory.Create(dto.player);
        }

        private List<Connection> CreateConnections(RootDTO dto) {
            List<Connection> connections = new List<Connection>();
            foreach (ConnectionDTO connectionDTO in dto.connections) {
                Connection connection = _connectionFactory.Create(connectionDTO);
                connections.Add(connection);
            }
            return connections;
        }

        private List<Room> CreateRooms(RootDTO dto, List<Connection> connections, Player player) {
            List<Room> rooms = new List<Room>();
            foreach (RoomDTO roomDTO in dto.rooms) {
                List<Connection> roomConnections = connections.Where(c => new[] { c.North, c.South, c.West, c.East, c.Within }.Contains(roomDTO.id)).ToList();
                Room room = _roomFactory.Create(roomDTO, roomConnections, player, dto.player.startRoomId);
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
