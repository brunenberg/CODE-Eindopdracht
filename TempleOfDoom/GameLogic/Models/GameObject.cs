using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLogic.Models {
    public abstract class GameObject {
        public string? Type { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
    }
}
