using CODE_TempleOfDoom_DownloadableContent;
using GameLogic.Entities;

namespace Data.Factories {
    public class EnemyFactory {
        public EnemyAdapter Create(EnemyDTO dto) {
            Enemy enemy;
            int lives = 3;

            switch (dto.type) {
                case "horizontal":
                    enemy = new HorizontallyMovingEnemy(lives, dto.x, dto.y, dto.minX, dto.maxY);
                    break;
                case "vertical":
                    enemy = new VerticallyMovingEnemy(lives, dto.x, dto.y, dto.minX, dto.maxY);
                    break;
                default:
                    throw new ArgumentException($"Enemy of type '{dto.type}' is not recognized");
            }

            EnemyAdapter enemyAdapter = new EnemyAdapter(enemy);

            enemyAdapter.OnDeath += Enemy_OnDeath;

            return enemyAdapter;
        }

        private void Enemy_OnDeath(object sender) {
            if (sender is Entity entity) {
                entity.CurrentRoom.RemoveObject(entity);
            }
        }
    }
}
