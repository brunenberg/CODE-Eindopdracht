using GameLogic.Items.Traps;
using GameLogic.Items;
using GameLogic.Tiles;
using GameLogic.Models;
using GameLogic.Decorators;

namespace Data.Factories {
    public static class SpecialFloorTileFactory {
        public static GameObject Create(SpecialFloorTileDTO dto) {
            switch (dto.type) {
                case "wall":
                    Wall wall = new Wall();
                    return wall;
                case "innerdoor": //TODO: Implement innerdoor
                    Wall wall1 = new Wall();
                    return wall1;
                default:
                    throw new ArgumentException("Unknown item type" + dto.type);
            }
        }
    }
}
