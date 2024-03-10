using GameLogic.Models;

namespace Data.Factories {
    public class ConnectionFactory {
        public Connection Create(ConnectionDTO dto) {
            Connection connection = new Connection {
                Door = DoorFactory.Create(dto.doors),
                IsHorizontal = dto.horizontal
            };

            if (dto.NORTH != null) {
                connection.North = dto.NORTH;
            }

            if (dto.SOUTH != null) {
                connection.South = dto.SOUTH;
            }

            if (dto.WEST != null) {
                connection.West = dto.WEST;
            }

            if (dto.EAST != null) {
                connection.East = dto.EAST;
            }

            if (dto.within != null) {
                connection.Within = dto.within;
            }

            return connection;
        }
    }
}
