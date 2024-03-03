
namespace GameLogic.Decorators {
    public class Passage : IDoor {
        public IDoor GetUnderlyingDoor() {
            return this;
        }
    }
}
