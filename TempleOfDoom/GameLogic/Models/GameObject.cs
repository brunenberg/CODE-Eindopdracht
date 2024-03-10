namespace GameLogic.Models {
    public abstract class GameObject {
        public string? Type { get; set; }
        public virtual int X { get; set; }
        public virtual int Y { get; set; }

        public void UpdateLocation(int x, int y) {
            X = x;
            Y = y;
        }
    }
}
