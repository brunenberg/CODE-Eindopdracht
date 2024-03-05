using CODE_TempleOfDoom_DownloadableContent;
using GameLogic.Entities;

public class EnemyAdapter : Entity {
    private Enemy _enemy;

    public EnemyAdapter(Enemy enemy) {
        _enemy = enemy;
    }

    public override int X {
        get { return _enemy.CurrentXLocation; }
        set { _enemy.CurrentXLocation = value; }
    }

    public override int Y {
        get { return _enemy.CurrentYLocation; }
        set { _enemy.CurrentYLocation = value; }
    }
}
