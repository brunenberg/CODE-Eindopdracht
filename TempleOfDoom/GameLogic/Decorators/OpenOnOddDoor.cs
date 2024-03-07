
using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class OpenOnOddDoor : DoorDecorator, IEnterable {
        public OpenOnOddDoor(IDoor door) : base(door) {
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            return entity.Lives % 2 != 0;
        }

        public void OnEnter(Root root, Entity entity) {
            // Nothing
        }
    }
}
