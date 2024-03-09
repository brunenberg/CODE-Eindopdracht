using GameLogic.Models;
using GameLogic.Tiles;

namespace Data.Factories {
    public static class SpecialFloorTileFactory {
        private static readonly Dictionary<string, Func<SpecialFloorTileDTO, GameObject>> specialFloorTileCreators = new Dictionary<string, Func<SpecialFloorTileDTO, GameObject>> {
            { "wall", dto => new Wall() },
            // TODO: Implement innerdoor
            { "innerdoor", dto => new Wall() }
        };

        public static GameObject Create(SpecialFloorTileDTO dto) {
            if (specialFloorTileCreators.TryGetValue(dto.type, out Func<SpecialFloorTileDTO, GameObject> createSpecialFloorTile)) {
                return createSpecialFloorTile(dto);
            } else {
                throw new ArgumentException($"Item of type '{dto.type}' is not recognized");
            }
        }
    }
}
