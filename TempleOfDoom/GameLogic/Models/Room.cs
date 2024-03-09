using GameLogic.Entities;
using GameLogic.Items;

namespace GameLogic.Models {
    public class Room {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Dictionary<(int, int), List<GameObject>> CoordinateObjects { get; set; }
        public int SankaraStoneAmount { get; set; }

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

        public void AddObjectOnLocation(GameObject obj, int x, int y) {
            if (CoordinateObjects.ContainsKey((x, y))) {
                CoordinateObjects[(x, y)].Add(obj);
            } else {
                CoordinateObjects[(x, y)] = new List<GameObject> { obj };
            }
        }

        public List<GameObject> GetObjectsAt(int x, int y) {
            if (CoordinateObjects.ContainsKey((x, y))) {
                return CoordinateObjects[(x, y)];
            } else {
                return new List<GameObject>();
            }
        }

        public List<GameObject> GetNonEntityObjectsForEntity(Entity entity) {
            List<GameObject> objectsAtCoordinates = new List<GameObject>(GetObjectsAt(entity.X, entity.Y));
            if (objectsAtCoordinates.Contains(entity)) {
                objectsAtCoordinates.Remove(entity);
            }
            return objectsAtCoordinates;
        }


        public void MoveObject(GameObject obj, int newX, int newY) {
            if (CoordinateObjects.ContainsKey((obj.X, obj.Y)) && CoordinateObjects[(obj.X, obj.Y)].Contains(obj)) {
                CoordinateObjects[(obj.X, obj.Y)].Remove(obj);

                if (CoordinateObjects[(obj.X, obj.Y)].Count == 0) {
                    CoordinateObjects.Remove((obj.X, obj.Y));
                }

                obj.X = newX;
                obj.Y = newY;

                AddObject(obj);
            } else {
                throw new Exception("Object not found at the specified location.");
            }
        }

        public void RemoveObject(GameObject obj) {
            if (CoordinateObjects.ContainsKey((obj.X, obj.Y)) && CoordinateObjects[(obj.X, obj.Y)].Contains(obj)) {
                CoordinateObjects[(obj.X, obj.Y)].Remove(obj);

                if (obj is SankaraStone) {
                    SankaraStoneAmount--;
                }

                if (CoordinateObjects[(obj.X, obj.Y)].Count == 0) {
                    CoordinateObjects.Remove((obj.X, obj.Y));
                }
            } else {
                throw new Exception("Object not found at the specified location.");
            }
        }

    }
}
