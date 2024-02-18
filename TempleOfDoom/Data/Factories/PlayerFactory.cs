using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Factories {
    public static class PlayerFactory {
        public static GameLogic.Entities.Player CreatePlayer(int startRoomId, int startX, int startY, int lives) {
            return new GameLogic.Entities.Player {
                StartRoomId = startRoomId,
                StartX = startX,
                StartY = startY,
                Lives = lives
            };
        }

    }
}
