using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Observers {
    public class Unsubscriber<Player> : IDisposable {
        public List<IObserver<Player>> _observers;
        public IObserver<Player> _observer;

        public Unsubscriber(List<IObserver<Player>> observers, IObserver<Player> observer) {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose() {
            if (_observer != null && _observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
