using GameLogic.Entities;

namespace Data.Factories {
    public class PlayerFactory {
        public Player Create(PlayerDTO dto) {
            return new Player {
                X = dto.startX,
                Y = dto.startY,
                Lives = dto.lives
            };
        }

    }
}
