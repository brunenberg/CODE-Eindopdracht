
using GameLogic.Models;

namespace GameLogic.Entities {
    public abstract class Entity : GameObject {
        public int CurrentRoomId { get; set; }
        public int Lives { get; set; }

        public void Move(Root root, Direction direction) {
            if (this is Entity entity) {
                Room currentRoom = root.Rooms.FirstOrDefault(room => room.Id == entity.CurrentRoomId);
                (int, int) delta = direction.GetDelta();
                int newX = this.X + delta.Item1;
                int newY = this.Y + delta.Item2;

                currentRoom.MoveObject(entity, newX, newY);
            }
        }
    }
}
