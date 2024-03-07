
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Entities {
    public abstract class Entity : GameObject {
        public int CurrentRoomId { get; set; }
        public Room CurrentRoom { get; set; }
        public int Lives { get; set; }
        public Direction LastMovedDirection { get; set; }

        public bool Move(Root root, Direction direction) {
            if (this is Entity entity) {
                (int, int) delta = direction.GetDelta();
                int newX = this.X + delta.Item1;
                int newY = this.Y + delta.Item2;

                if (!IsMovePossible(root, newX, newY)) {
                    return false;
                }

                CurrentRoom.MoveObject(entity, newX, newY);
                LastMovedDirection = direction;
            }
            return true;
        }

        public bool IsMovePossible(Root root, int x, int y) {
            foreach (GameObject obj in CurrentRoom.GetObjectsAt(x, y)) {
                if (obj is IEnterable enterable && !enterable.CanEntityEnter(root, this)) {
                    return false;
                }
            }
            return true;
        }

        public void InteractWithCurrentLocation(Root root, Entity entity) {
            foreach (GameObject obj in entity.CurrentRoom.GetNonEntityObjectsForEntity(entity)) {
                if (obj is IEnterable enterableObj) {
                    enterableObj.OnEnter(root, entity);
                }
            }
        }

    }
}
