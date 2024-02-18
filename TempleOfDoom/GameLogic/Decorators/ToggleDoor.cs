using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Decorators {
    public class ToggleDoor : DoorDecorator {
        public ToggleDoor(IDoor door) : base(door) {
        }
    }
}
