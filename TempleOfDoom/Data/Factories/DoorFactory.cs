using GameLogic.Decorators;

namespace Data.Factories {
    public static class DoorFactory {
        private static readonly Dictionary<string, Func<DoorDTO, IDoor, IDoor>> doorDecorators = new Dictionary<string, Func<DoorDTO, IDoor, IDoor>> {
            { "colored", (dto, door) => new ColoredDoor(door, dto.color) },
            { "toggle", (dto, door) => new ToggleDoor(door, false) },
            { "closing gate", (dto, door) => new ClosingGateDoor(door) },
            { "open on odd", (dto, door) => new OpenOnOddDoor(door) },
            { "open on stones in room", (dto, door) => new OpenOnStonesDoor(door, dto.no_of_stones) },
            { "switched", (dto, door) => new SwitchDoor(door) }
        };

        public static IDoor Create(DoorDTO[] dtos) {
            IDoor door = new Passage();

            foreach (DoorDTO dto in dtos) {
                if (doorDecorators.TryGetValue(dto.type, out Func<DoorDTO, IDoor, IDoor> createDecorator)) {
                    door = createDecorator(dto, door);
                } else {
                    throw new ArgumentException($"Door of type '{dto.type}' is not recognized");
                }
            }

            return door;
        }
    }
}
