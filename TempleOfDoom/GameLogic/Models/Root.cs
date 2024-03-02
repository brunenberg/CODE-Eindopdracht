using GameLogic.Entities;

namespace GameLogic.Models {
    public class Root {
        public List<Room>? Rooms { get; set; }
        public List<Connection>? Connections { get; set; }
        public Player? Player { get; set; }
    }
}
