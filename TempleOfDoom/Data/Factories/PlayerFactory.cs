using GameLogic.Entities;

namespace Data.Factories {
    public class PlayerFactory {
        public Player Create(PlayerDTO dto) {
            Player player = new Player {
                X = dto.startX,
                Y = dto.startY,
                Lives = dto.lives
            };

            player.OnDeath += Player_OnDeath;

            return player;
        }

        private void Player_OnDeath(object sender) {
            if (sender is Entity entity) {
                entity.CurrentRoom.RemoveObject(entity);
            }
        }
    }
}
