using GameLogic.Models;

namespace Data.Factories {
    public class ConnectionFactory {
        public Connection Create(ConnectionDTO dto) {
            return new Connection {
                North = dto.NORTH,
                South = dto.SOUTH,
                West = dto.WEST,
                East = dto.EAST,
                Door = DoorFactory.Create(dto.doors),
            };
        }
    }
}
