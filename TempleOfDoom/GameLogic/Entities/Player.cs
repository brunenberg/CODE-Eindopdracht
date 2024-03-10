using GameLogic.Models;
using GameLogic.Observers;

namespace GameLogic.Entities {
    public class Player : Entity, IObservable<Player> {
        private readonly List<IObserver<Player>> observers;
        public List<GameObject> Inventory { get; set; }

        public Player() {
            observers = new List<IObserver<Player>>();
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

        public IDisposable Subscribe(IObserver<Player> observer) {
            if (!observers.Contains(observer))
                observers.Add(observer);
            return new Unsubscriber<Player>(observers, observer);
        }

        public void Notify() {
            foreach (var observer in observers) {
                observer.OnNext(this);
            }
        }
    }
}
