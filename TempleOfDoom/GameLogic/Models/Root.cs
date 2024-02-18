using GameLogic.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Models {
    public class Root {
        public List<Room> Rooms { get; set; }
        public List<Connection> Connections { get; set; }
        public Player Player { get; set; }
    }
}
