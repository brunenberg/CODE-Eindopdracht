
using GameLogic.Models;
using GameLogic.Tiles;

namespace GameLogic.Entities {
    public abstract class Entity : GameObject {
        public int CurrentRoomId { get; set; }
        public Room CurrentRoom { get; set; }
        public int Lives { get; set; }

        public bool Move(Root root, Direction direction) {
            if (this is Entity entity) {
                (int, int) delta = direction.GetDelta();
                int newX = this.X + delta.Item1;
                int newY = this.Y + delta.Item2;

                if (!IsMovePossible(newX, newY)) {
                    return false;
                }

                CurrentRoom.MoveObject(entity, newX, newY);
            }
            return true;
        }

        public bool IsMovePossible(int x, int y) {
            foreach (GameObject obj in CurrentRoom.GetObjectsAt(x, y)) {
                if (obj is Wall) {
                    return false;
                }
            }
            return true;
        }
    }
}
