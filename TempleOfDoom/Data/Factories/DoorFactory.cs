using GameLogic.Decorators;

namespace Data.Factories {
    public static class DoorFactory {
        private static readonly Dictionary<string, Func<DoorDTO, IDoor, IDoor>> doorDecorators = new Dictionary<string, Func<DoorDTO, IDoor, IDoor>> {
            { "colored", (dto, door) => new ColoredDoor(door, dto.color) },
            { "toggle", (dto, door) => new ToggleDoor(door) },
            { "closing gate", (dto, door) => new ClosingGateDoor(door) },
            { "open on odd", (dto, door) => new OpenOnOddDoor(door) },
            { "open on stones in room", (dto, door) => new OpenOnStonesDoor(door, dto.no_of_stones) },
            { "switched", (dto, door) => new SwitchDoor(door) }
        };

        public static IDoor Create(DoorDTO[] dtos) {
            if (dtos.Length == 0) {
                //TODO: IMPLEMENT
                //return een connection zonder door?? 
            }

            IDoor door = new BasicDoor();

            foreach (DoorDTO dto in dtos) {
                if (doorDecorators.TryGetValue(dto.type, out Func<DoorDTO, IDoor, IDoor> createDecorator)) {
                    door = createDecorator(dto, door);
                } else {
                    throw new ArgumentException($"Unknown item type '{dto.type}'");
                }
            }

            return door;
        }
    }
}
