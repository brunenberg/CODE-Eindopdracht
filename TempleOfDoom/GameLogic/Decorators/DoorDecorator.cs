using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Decorators {
    public class DoorDecorator : IDoor {
        protected IDoor _door;

        public DoorDecorator(IDoor door) {
            _door = door;
        }
    }
}
