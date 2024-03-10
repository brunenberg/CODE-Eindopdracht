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
        public bool? IsHorizontal { get; set; }
        public int? Within { get; set; }

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
            if (this.Within.HasValue) {
                MoveEntityWithinRoom(root, entity);
            } else {
                MoveEntityToNewRoom(root, entity);
            }
        }

        private void MoveEntityWithinRoom(Root root, Entity entity) {
            var directionToOffset = new Dictionary<Direction, (int dx, int dy)> {
                { Direction.NORTH, (0, -1) },
                { Direction.EAST, (1, 0) },
                { Direction.SOUTH, (0, 1) },
                { Direction.WEST, (-1, 0) }
            };

            if (directionToOffset.TryGetValue(entity.LastMovedDirection, out var offset)) {
                entity.CurrentRoom.MoveObject(entity, X + offset.dx, Y + offset.dy);
            }
            entity.InteractWithCurrentLocation(root, entity);
        }

        private void MoveEntityToNewRoom(Root root, Entity entity) {
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

                var directionToPosition = new Dictionary<Direction, (int x, int y)> {
                    { Direction.NORTH, (newRoom.Width / 2, newRoom.Height - 1 - offset) },
                    { Direction.EAST, (offset, newRoom.Height / 2) },
                    { Direction.SOUTH, (newRoom.Width / 2, offset) },
                    { Direction.WEST, (newRoom.Width - 1 - offset, newRoom.Height / 2) }
                };

                if (directionToPosition.TryGetValue(entity.LastMovedDirection, out var position)) {
                    entity.UpdateLocation(position.x, position.y);
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
