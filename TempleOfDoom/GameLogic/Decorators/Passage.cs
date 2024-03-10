
using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class Passage : IDoor, IEnterable {

        public IDoor GetUnderlyingDoor() {
            return null;
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            return true;
        }

        public void OnEnter(Root root, Entity entity) {
            // Nothing
        }
    }
}
