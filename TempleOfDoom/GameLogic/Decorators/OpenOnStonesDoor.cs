using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Decorators {
    public class OpenOnStonesDoor : DoorDecorator {
        public int NumberOfStones { get; set; }

        public OpenOnStonesDoor(IDoor door, int numberOfStones) : base(door) {
            NumberOfStones = numberOfStones;
        }
    }
}
