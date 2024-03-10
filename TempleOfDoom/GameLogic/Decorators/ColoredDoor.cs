
using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Items;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class ColoredDoor : DoorDecorator, IEnterable {
        public string Color { get; set; }

        public ColoredDoor(IDoor door, string color) : base(door) {
            Color = color;
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            if (entity is Player player) {
                return player.Inventory.OfType<Key>().Any(key => key.Color == this.Color);
            }
            return false;
        }


        public void OnEnter(Root root, Entity entity) {
            // Nothing
        }
    }
}
