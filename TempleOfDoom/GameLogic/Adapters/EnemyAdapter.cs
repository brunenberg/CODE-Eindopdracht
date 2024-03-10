using CODE_TempleOfDoom_DownloadableContent;
using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

public class EnemyAdapter : Entity, IEnterable {
    private Enemy _enemy;

    public EnemyAdapter(Enemy enemy) {
        _enemy = enemy;
        Lives = _enemy.NumberOfLives;
    }

    public override int X {
        get { return _enemy.CurrentXLocation; }
        set { _enemy.CurrentXLocation = value; }
    }

    public override int Y {
        get { return _enemy.CurrentYLocation; }
        set { _enemy.CurrentYLocation = value; }
    }

    public bool CanEntityEnter(Root root, Entity entity) {
        return true;
    }

    public void OnEnter(Root root, Entity entity) {
        entity.TakeDamage(Damage);
    }
}
