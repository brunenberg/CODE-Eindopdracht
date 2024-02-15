﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data {

    public class RootDTO {
        public RoomDTO[]? rooms { get; set; }
        public ConnectionDTO[]? connections { get; set; }
        public PlayerDTO? player { get; set; }
    }
    public class RoomDTO {
        private int _width;
        private int _height;

        public int id { get; set; }
        public string? type { get; set; }

        public int width {
            get { return _width; }
            set { _width = Math.Max(3, Math.Min(50, value)); }
        }

        public int height {
            get { return _height; }
            set { _height = Math.Max(3, Math.Min(50, value)); }
        }

        public ItemDTO[]? items { get; set; }
        public EnemyDTO[]? enemies { get; set; }
    }


    public class ItemDTO {
        public string? type { get; set; }
        public int? damage { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public string? color { get; set; }
    }

    public class DoorDTO {
        public string? type { get; set; }
        public string? color { get; set; }
        public int? no_of_stones { get; set; }
    }

    public class PlayerDTO {
        public int startRoomId { get; set; }
        public int startX { get; set; }
        public int startY { get; set; }
        public int lives { get; set; }
    }

    public class ConnectionDTO {
        public int? NORTH { get; set; }
        public int? SOUTH { get; set; }
        public DoorDTO[]? doors { get; set; }
        public int? WEST { get; set; }
        public int? EAST { get; set; }
    }

    public class EnemyDTO {
        public string ?type { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int minX { get; set; }
        public int minY { get; set; }
        public int maxX { get; set; }
        public int maxY { get; set; }
    }
}