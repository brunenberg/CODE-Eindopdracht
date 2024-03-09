using CODE_TempleOfDoom_DownloadableContent;

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

            return enemyAdapter;
        }
    }
}
