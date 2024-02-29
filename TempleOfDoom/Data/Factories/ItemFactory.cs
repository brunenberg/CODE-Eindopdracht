using GameLogic.Items;
using GameLogic.Items.Traps;

namespace Data.Factories {
    public static class ItemFactory {
        private static readonly Dictionary<string, Func<ItemDTO, Item>> itemCreators = new Dictionary<string, Func<ItemDTO, Item>> {
            { "sankara stone", dto => new SankaraStone { X = dto.x, Y = dto.y } },
            { "key", dto => new Key { Color = dto.color, X = dto.x, Y = dto.y } },
            { "boobytrap", dto => new BoobyTrap { Damage = dto.damage, X = dto.x, Y = dto.y } },
            { "disappearing boobytrap", dto => new DisappearingBoobyTrap { Damage = dto.damage, X = dto.x, Y = dto.y } },
            { "pressure plate", dto => new PressurePlate { X = dto.x, Y = dto.y } }
        };

        public static Item Create(ItemDTO dto) {
            if (itemCreators.TryGetValue(dto.type, out Func<ItemDTO, Item> createItem)) {
                return createItem(dto);
            } else {
                throw new ArgumentException("Unknown item type" + dto.type);
            }
        }
    }
}
