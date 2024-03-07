using GameLogic.Entities;
using GameLogic.Models;

namespace GameLogic.Interfaces {
    public interface IEnterable {
        public bool CanEntityEnter(Root root, Entity entity);
        public void OnEnter(Root root, Entity entity);
    }
}
