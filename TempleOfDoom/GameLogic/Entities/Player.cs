using GameLogic.Models;
using GameLogic.Observers;

namespace GameLogic.Entities {
    public class Player : IObservable<Player> {
        private readonly List<IObserver<Player>> observers;

        public int StartRoomId { get; set; }
        public int StartX { get; set; }
        public int StartY { get; set; }
        public int Lives { get; set; }
        public List<GameObject> Inventory { get; set; }

        public Player() {
            observers = new List<IObserver<Player>>();
            Inventory = new List<GameObject>();
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
