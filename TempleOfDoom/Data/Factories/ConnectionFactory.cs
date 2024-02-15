using GameLogic.Doors;
using GameLogic.Items;
using GameLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factories {
    public static class ConnectionFactory {
        public static Connection Create(ConnectionDTO dto) {
            return new Connection {
                North = dto.NORTH,
                South = dto.SOUTH,
                West = dto.WEST,
                East = dto.EAST,
                Door = dto.doors != null ? dto.doors.Select(doorDto => DoorFactory.Create(doorDto)).ToList() : new List<Door>(),
            };
        }
    }
}
