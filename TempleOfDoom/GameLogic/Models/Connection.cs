using GameLogic.Decorators;
using GameLogic.Entities;
using GameLogic.Interfaces;

namespace GameLogic.Models {
    public class Connection : GameObject, IEnterable {
        public int? North { get; set; }
        public int? East { get; set; }
        public int? South { get; set; }
        public int? West { get; set; }
        public IDoor? Door { get; set; }

        public bool CanEntityEnter(Root root, Entity entity) {
            IDoor door = this.Door;
            while (door != null) {
                if (door is IEnterable enterable && !enterable.CanEntityEnter(root, entity)) {
                    return false;
                }
                door = door.GetUnderlyingDoor();
            }
            return true;
        }

        public void OnEnter(Root root, Entity entity) {
            var directionToRoomId = new Dictionary<Direction, int?> {
        { Direction.NORTH, North },
        { Direction.EAST, East },
        { Direction.SOUTH, South },
        { Direction.WEST, West }
    };

            const int offset = 1;

            if (directionToRoomId.TryGetValue(entity.LastMovedDirection, out int? roomId)) {
                entity.CurrentRoom.RemoveObject(entity);
                Room newRoom = root.Rooms.FirstOrDefault(room => room.Id == roomId);
                entity.CurrentRoom = newRoom;

                switch (entity.LastMovedDirection) {
                    case Direction.NORTH:
                        entity.X = newRoom.Width / 2;
                        entity.Y = newRoom.Height - 1 - offset;
                        break;
                    case Direction.EAST:
                        entity.X = offset;
                        entity.Y = newRoom.Height / 2;
                        break;
                    case Direction.SOUTH:
                        entity.X = newRoom.Width / 2;
                        entity.Y = offset;
                        break;
                    case Direction.WEST:
                        entity.X = newRoom.Width - 1 - offset;
                        entity.Y = newRoom.Height / 2;
                        break;
                }

                newRoom.AddObject(entity);

                IDoor door = this.Door;
                while (door != null) {
                    if (door is IEnterable enterable) {
                        enterable.OnEnter(root, entity);
                    }
                    door = door.GetUnderlyingDoor();
                }

                entity.InteractWithCurrentLocation(root, entity);
            }
        }
    }
}
