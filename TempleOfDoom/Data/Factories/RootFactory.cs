using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Entities;
using GameLogic.Models;

namespace Data.Factories {
    public static class RootFactory {
        public static Root Create(RootDTO dto) {
            Root root = new Root {
                Rooms = CreateRooms(dto),
                Connections = CreateConnections(dto),
                Player = CreatePlayer(dto)
        };
            return root;
        }

        private static List<Room> CreateRooms(RootDTO dto) {
            List<Room> rooms = new List<Room>();
            foreach(RoomDTO roomDTO in dto.rooms) {
                Room room = RoomFactory.Create(roomDTO);
                rooms.Add(room);
            }
            return rooms;
        }

        private static List<Connection> CreateConnections(RootDTO dto) {
            List<Connection> connections = new List<Connection>();
            foreach (ConnectionDTO connectionDTO in dto.connections) {
                Connection connection = ConnectionFactory.Create(connectionDTO);
                connections.Add(connection);
            }
            return connections;
        }

        private static Player CreatePlayer(RootDTO dto) {
            return PlayerFactory.Create(dto.player);
        }
    }
}
