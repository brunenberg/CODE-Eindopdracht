using GameLogic.Decorators;

namespace Data.Factories {
    public static class DoorFactory {
        public static IDoor Create(DoorDTO[] dtos) {

            if (dtos.Length == 0) {

            }

            IDoor door = new BasicDoor();

            foreach(DoorDTO dto in dtos) {
                switch (dto.type) {
                    case "colored":
                        door = new ColoredDoor(door, dto.color);
                        break;
                    case "toggle":
                        door = new ToggleDoor(door);
                        break;
                    case "closing gate":
                        door = new ClosingGateDoor(door);
                        break;
                    case "open on odd":
                        door = new OpenOnOddDoor(door);
                        break;
                    case "open on stones in room":
                        door = new OpenOnStonesDoor(door, dto.no_of_stones);
                        break;
                    case "switched":
                        door = new SwitchDoor(door);
                        break;
                    default:
                        throw new ArgumentException($"Unknown item type '{dto.type}'");
                }
            }

            return door;
        }
    }
}
