using System.Collections.Generic;
using GameLogic.Entities;
using GameLogic.Items;
using GameLogic.Tiles;

namespace GameLogic.Models {
    public class Room {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Dictionary<(int, int), List<GameObject>> CoordinateObjects { get; set; }

        public Room() {
            CoordinateObjects = new Dictionary<(int, int), List<GameObject>>();
        }

        public void AddObject(GameObject obj) {
            if (CoordinateObjects.ContainsKey((obj.X, obj.Y))) {
                CoordinateObjects[(obj.X, obj.Y)].Add(obj);
            } else {
                CoordinateObjects[(obj.X, obj.Y)] = new List<GameObject> { obj };
            }
        }

        public List<GameObject> GetObjectsAt(int x, int y) {
            if (CoordinateObjects.ContainsKey((x, y))) {
                return CoordinateObjects[(x, y)];
            } else {
                return new List<GameObject>();
            }
        }
    }
}
