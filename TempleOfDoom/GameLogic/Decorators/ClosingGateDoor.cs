using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Decorators {
    public class ClosingGateDoor : DoorDecorator {
        public ClosingGateDoor(IDoor door) : base(door) {
        }
    }
}
