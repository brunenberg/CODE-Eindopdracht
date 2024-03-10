using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Items.Traps {
    public class BoobyTrap : Trap, IEnterable {
        public bool CanEntityEnter(Root root, Entity entity) {
            return true;
        }

        public void OnEnter(Root root, Entity entity) {
            entity.TakeDamage(Damage);
        }
    }
}
