using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Items.Traps {
    public abstract class Trap : Item {
        public int? Damage { get; set; }
    }
}
