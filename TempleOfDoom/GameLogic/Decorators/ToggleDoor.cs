
using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class ToggleDoor : DoorDecorator, IEnterable {
        public bool IsOpen { get; set; }
        public ToggleDoor(IDoor door, bool isOpen) : base(door) {
            IsOpen = isOpen;
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            return true;
        }

        public void OnEnter(Root root, Entity entity) {
            // Nothing
        }
    }
}
