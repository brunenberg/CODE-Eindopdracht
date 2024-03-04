
namespace GameLogic.Decorators {
    public class ToggleDoor : DoorDecorator {
        public bool IsOpen { get; set; }
        public ToggleDoor(IDoor door, bool isOpen) : base(door) {
            IsOpen = isOpen;
        }
    }
}
