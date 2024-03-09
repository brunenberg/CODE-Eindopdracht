using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Items {
    public class SankaraStone : Item, IEnterable {
        public bool CanEntityEnter(Root root, Entity entity) {
            return true;
        }

        public void OnEnter(Root root, Entity entity) {
            if (entity is Player player) {
                player.Inventory.Add(this);
                player.CurrentRoom.RemoveObject(this);
            }
        }
    }
}
