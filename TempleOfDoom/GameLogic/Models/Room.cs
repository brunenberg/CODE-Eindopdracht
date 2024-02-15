using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLogic.Entities;
using GameLogic.Items;

namespace GameLogic.Models {
    public class Room {
        public int Id { get; set; }
        public string Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public List<Item> Items { get; set; }
        public List<Enemy> Enemies { get; set; }
    }
}
