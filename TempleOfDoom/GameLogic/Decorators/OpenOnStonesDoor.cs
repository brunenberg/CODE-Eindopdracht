using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Items;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class OpenOnStonesDoor : DoorDecorator, IEnterable {
        public int NumberOfStones { get; set; }

        public OpenOnStonesDoor(IDoor door, int numberOfStones) : base(door) {
            NumberOfStones = numberOfStones;
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            if (entity is Player player) {
                int playerStoneAmount = player.Inventory.OfType<SankaraStone>().Count();
                return playerStoneAmount == NumberOfStones;
            }
            return false;
        }

        public void OnEnter(Root root, Entity entity) {
            // Nothing
        }
    }
}
