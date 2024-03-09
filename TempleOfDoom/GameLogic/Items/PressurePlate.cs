using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Items {
    public class PressurePlate : Item, IEnterable, ISubject {
        private List<IObserver> observers = new List<IObserver>();

        public void RegisterObserver(IObserver observer) {
            observers.Add(observer);
        }

        public void RemoveObserver(IObserver observer) {
            observers.Remove(observer);
        }

        public void NotifyObservers() {
            foreach (IObserver observer in observers) {
                observer.Update();
            }
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            return true;
        }

        public void OnEnter(Root root, Entity entity) {
            NotifyObservers();
        }
    }

}
