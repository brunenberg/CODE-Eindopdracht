using GameLogic.Items.Traps;
using GameLogic.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Doors;

namespace Data.Factories {
    public static class DoorFactory {
        public static Door Create(DoorDTO dto) {
            switch (dto.type) {
                case "colored":
                    ColoredDoor coloredDoor = new ColoredDoor();
                    coloredDoor.Color = dto.color;
                    return coloredDoor;
                case "toggle":
                    ToggleDoor toggleDoor = new ToggleDoor();
                    return toggleDoor;
                case "closing gate":
                    ClosingGateDoor closingGateDoor = new ClosingGateDoor();
                    return closingGateDoor;
                case "open on odd":
                    OpenOnOddDoor openOnOddDoor = new OpenOnOddDoor();
                    return openOnOddDoor;
                case "open on stones in room":
                    OpenOnStonesInRoomDoor openOnStonesInRoomDoor = new OpenOnStonesInRoomDoor();
                    return openOnStonesInRoomDoor;
                default:
                    throw new ArgumentException("Unknown item type" + dto.type);
            }
        }
    }
}
