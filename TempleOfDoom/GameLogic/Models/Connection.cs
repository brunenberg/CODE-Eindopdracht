using GameLogic.Doors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Models {
    public class Connection {
        public int? North { get; set; }
        public int? East { get; set; }
        public int? South { get; set; }
        public int? West { get; set; }
        public List<Door>? Door { get; set; }
    }
}
