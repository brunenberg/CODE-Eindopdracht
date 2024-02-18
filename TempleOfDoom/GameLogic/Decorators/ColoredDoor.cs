using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Decorators {
    public class ColoredDoor : DoorDecorator {
        public string Color { get; set; }

        public ColoredDoor(IDoor door, string color) : base(door) {
            Color = color;
        }
    }
}
