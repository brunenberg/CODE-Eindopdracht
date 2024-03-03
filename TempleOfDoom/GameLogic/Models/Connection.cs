using GameLogic.Decorators;

namespace GameLogic.Models {
    public class Connection : GameObject {
        public int? North { get; set; }
        public int? East { get; set; }
        public int? South { get; set; }
        public int? West { get; set; }
        public IDoor? Door { get; set; }
    }
}
