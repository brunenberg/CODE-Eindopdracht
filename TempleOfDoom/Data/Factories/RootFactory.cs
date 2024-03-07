using GameLogic.Entities;
using GameLogic.Models;

namespace Data.Factories {
    public static class RootFactory {
        public static Root Create(RootDTO dto) {
            Player player = CreatePlayer(dto);
            List<Connection> connections = CreateConnections(dto);
            List<Room> rooms = CreateRooms(dto, connections, player);

            return new Root {
                Rooms = rooms,
                Connections = connections,
                Player = player
            };
        }
        private static Player CreatePlayer(RootDTO dto) {
            return PlayerFactory.Create(dto.player);
        }
        private static List<Connection> CreateConnections(RootDTO dto) {
            List<Connection> connections = new List<Connection>();
            foreach (ConnectionDTO connectionDTO in dto.connections) {
                Connection connection = ConnectionFactory.Create(connectionDTO);
                connections.Add(connection);
            }
            return connections;
        }

        private static List<Room> CreateRooms(RootDTO dto, List<Connection> connections, Player player) {
            List<Room> rooms = new List<Room>();
            foreach (RoomDTO roomDTO in dto.rooms) {
                List<Connection> roomConnections = connections.Where(c => c.North == roomDTO.id || c.South == roomDTO.id || c.West == roomDTO.id || c.East == roomDTO.id).ToList();
                Room room = RoomFactory.Create(roomDTO, roomConnections, player, dto.player.startRoomId);
                rooms.Add(room);
            }
            return rooms;
        }
    }
}
