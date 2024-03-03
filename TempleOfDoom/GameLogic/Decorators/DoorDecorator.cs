namespace GameLogic.Decorators {
    public class DoorDecorator : IDoor {
        protected IDoor _door;

        public DoorDecorator(IDoor door) {
            _door = door;
        }

        public IDoor GetUnderlyingDoor() {
            return _door;
        }
    }
}
