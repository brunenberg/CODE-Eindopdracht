using GameLogic.Entities;

namespace Data.Factories {
    public static class PlayerFactory {
        public static Player Create(PlayerDTO dto) {
            return new Player {
                StartRoomId = dto.startRoomId,
                StartX = dto.startX,
                StartY = dto.startY,
                Lives = dto.lives
            };
        }

    }
}
