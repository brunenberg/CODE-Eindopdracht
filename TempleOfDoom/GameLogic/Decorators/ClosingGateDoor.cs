using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class ClosingGateDoor : DoorDecorator, IEnterable {
        public bool DidEntityEnter { get; set; } = false;
        public ClosingGateDoor(IDoor door) : base(door) {
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            return !DidEntityEnter;
        }

        public void OnEnter(Root root, Entity entity) {
            DidEntityEnter = true;
        }
    }
}
