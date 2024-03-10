using GameLogic.Models;

namespace GameLogic.Entities {
    public class Player : Entity {
        public List<GameObject> Inventory { get; set; }

        public Player() {
            Inventory = new List<GameObject>();
        }

        public bool Shoot(Root root) {
            bool shot = false;
            foreach (Direction direction in Enum.GetValues(typeof(Direction))) {
                (int deltaX, int deltaY) = direction.GetDelta();
                int newX = this.X + deltaX;
                int newY = this.Y + deltaY;
                List<Entity> entities = CurrentRoom.GetEntityObjectsAt(newX, newY);
                foreach (Entity entity in entities) {
                    entity.TakeDamage(1);
                    shot = true;
                }
            }
            return shot;
        }
    }
}
