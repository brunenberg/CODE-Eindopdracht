using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class SwitchDoor : DoorDecorator, IEnterable {
        public SwitchDoor(IDoor door) : base(door) {
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            return true;
        }

        public void OnEnter(Root root, Entity entity) {
            // Nothing
        }
    }
}
