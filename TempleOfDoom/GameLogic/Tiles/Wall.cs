using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Tiles {
    public class Wall : GameObject, IEnterable {
        public bool CanEntityEnter(Root root, Entity entity) {
            return false;
        }

        public void OnEnter(Root root, Entity entity) {
            throw new NotImplementedException();
        }
    }
}
