using GameLogic.Entities;
using GameLogic.Interfaces;
using GameLogic.Models;

namespace GameLogic.Decorators {
    public class OpenOnStonesDoor : DoorDecorator, IEnterable {
        public int NumberOfStones { get; set; }

        public OpenOnStonesDoor(IDoor door, int numberOfStones) : base(door) {
            NumberOfStones = numberOfStones;
        }

        public bool CanEntityEnter(Root root, Entity entity) {
            return NumberOfStones == entity.CurrentRoom.SankaraStoneAmount;
        }

        public void OnEnter(Root root, Entity entity) {
            // Nothing
        }
    }
}
